// Copyright (c) 2007, LShift Ltd. <query@lshift.net>
// Copyright (c) 2007, Tony Garnock-Jones <tonyg@kcbbs.gen.nz>
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
//
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Xml;
using System.Linq;

namespace com.rabbitmq.tools.ndocproc {
    public class NDocProc {
        public static void Main(string[] args_array) {
            new NDocProc(new ArrayList(args_array));
        }

        public void Banner() {
            foreach (string s in new string[] {
                "NDocProc.exe -- .NET XML documentation processor",
                "Copyright (c) 2007, LShift Ltd. <query@lshift.net>",
                "Copyright (c) 2007, Tony Garnock-Jones <tonyg@kcbbs.gen.nz>",
                "==========================================================================="
            }) {
                Console.Out.WriteLine(s);
            }
        }

        public void Usage() {
            Console.Error.WriteLine("Usage: ndocproc [options] <destdir> <xmlfile> [<xmlfile> [...]]");
            Console.Error.WriteLine("  where each option can be:");
            Console.Error.WriteLine("    /nonpublic               include non-public members");
            Console.Error.WriteLine("    /nogoogledtypes          suppress \"I'm feeling lucky\" links");
            Console.Error.WriteLine("    /suppress:<namespace>    suppress analysis of items in <namespace>");
            Environment.Exit(1);
        }

        public void HandleOption(string opt) {
            if (opt == "/nonpublic") {
                includeNonpublic = true;
            } else if (opt == "/nogoogledtypes") {
                googleNonlocalTypes = false;
            } else if (opt.StartsWith("/suppress:")) {
                string ns = opt.Substring(10);
                suppressedNamespaces[ns] = ns;
                Log("Suppressing namespace "+ns);
            }
        }

        public NDocProc(ArrayList args) {
            Banner();

            while (args.Count > 0 && IsOptionName((string)args[0]))
            {
                HandleOption((string) args[0]);
                args.RemoveAt(0);
            }

            if (args.Count < 2) {
                Usage();
            }

            this.destdir = (string) args[0];
            args.RemoveAt(0);

            Directory.CreateDirectory(destdir);

            foreach (string xmlFilename in args) {
                Load(xmlFilename);
            }

            Reflect();
            Generate();
        }

        private static bool IsOptionName(string s)
        {
            return (s.StartsWith("/no") || s.StartsWith("/suppress"));
        }

        ///////////////////////////////////////////////////////////////////////////

        public string destdir;

        public IDictionary<string, Assembly> assemblies = new Dictionary<string, Assembly>();
        public IDictionary<string, XmlNode> members = new Dictionary<string, XmlNode>();
        public IDictionary<string, ArrayList> namespaces = new Dictionary<string, ArrayList>();
        public IDictionary<string, Type> types = new Dictionary<string, Type>();
        public IDictionary<Type, ArrayList> knownSubtypes = new Dictionary<Type, ArrayList>();
        public IDictionary<string, string> suppressedNamespaces = new Dictionary<string, string>();

        public bool includeNonpublic = false;
        public bool googleNonlocalTypes = true;

        public void Log(object message) {
            Console.Error.WriteLine("* " + message);
        }

        public string FullPath(string leaf) {
            return Path.Combine(destdir, leaf);
        }

        public XmlWriter OpenOut(string leaf) {
            string path = FullPath(leaf);
            Log("Creating " + path);
            XmlTextWriter w = new XmlTextWriter(path, Encoding.UTF8);
            w.Formatting = Formatting.Indented;
            return w;
        }

        public string MakeAssemblyPath(string assemblyName) {
            return assemblyName + ".dll";
        }

        public Assembly LoadAssembly(string xmlFilename, string assemblyPath) {
            try {
                return Assembly.LoadFrom(assemblyPath);
            } catch (FileNotFoundException) {
                return Assembly.LoadFrom(Path.Combine(Path.GetDirectoryName(xmlFilename),
                                                      assemblyPath));
            }
        }

        public void Load(string xmlFilename) {
            Log("Loading XML "+xmlFilename);
            XmlDocument d = new XmlDocument();
            d.Load(xmlFilename);

            foreach (XmlNode assemblyNode in d.SelectNodes("/doc/assembly")) {
                string assemblyName = assemblyNode.SelectSingleNode("name").InnerText;
                Assembly a;
                if (!assemblies.ContainsKey(assemblyName)) {
                    string assemblyPath = MakeAssemblyPath(assemblyName);
                    Log("Loading Assembly "+assemblyPath);
                    a = LoadAssembly(xmlFilename, assemblyPath);
                    assemblies[assemblyName] = a;
                } else {
                    a = (Assembly) assemblies[assemblyName];
                }
            }

            foreach (XmlNode memberNode in d.SelectNodes("//member")) {
                members[memberNode.SelectSingleNode("@name").InnerText] = memberNode;
            }
        }

        public sealed class MemberInfoNameComparer: IComparer {
            int IComparer.Compare(Object a, Object b) {
                return ((string) ((MemberInfo) a).Name).CompareTo(((MemberInfo) b).Name);
            }
        }

        public void AddKnownSubtype(Type _base, Type derived) {
            if (_base != null) {
                if (!knownSubtypes.ContainsKey(_base)) {
                    knownSubtypes[_base] = new ArrayList();
                }
                ((ArrayList) knownSubtypes[_base]).Add(derived);
            }
        }

        public string Namespace(Type t) {
            return (t.Namespace != null) ? t.Namespace : "";
        }

        public void Reflect() {
            foreach (var entry in assemblies) {
                var a = entry.Value;
                foreach (Type t in a.GetTypes()) {
                    if (!namespaces.ContainsKey(Namespace(t))) {
                        namespaces[Namespace(t)] = new ArrayList();
                    }
                    ((ArrayList) namespaces[Namespace(t)]).Add(t);
                    types[t.FullName] = t;
                }
            }
            foreach (var entry in types) {
                Type t = (Type) entry.Value;
                AddKnownSubtype(t.BaseType, t);
                foreach (Type i in GetDirectInterfaces(t)) {
                    AddKnownSubtype(i, t);
                }
            }
        }

        public Type[] GetDirectInterfaces(Type t) {
            if (t.BaseType == null) {
                return t.GetInterfaces();
            } else {
                Type[] baseInterfaces = t.BaseType.GetInterfaces();
                return t.FindInterfaces(new TypeFilter(InterfaceRejector), baseInterfaces);
            }
        }

        // I find it fascinating that after so many decades of support
        // for closures, we're still stuck in a C-style mentality of
        // passing function-pointer that take an explicit context
        // argument rather than a proper closure object.
        public static bool InterfaceRejector(Type candidate, Object criteria) {
            Type[] interfacesToReject = (Type[]) criteria;
            foreach (Type t in interfacesToReject) {
                if (candidate.Equals(t))
                    return false;
            }
            return true;
        }

        public ICollection Sorted(ICollection other, IComparer cmp) {
            ArrayList result = new ArrayList(other);
            result.Sort(cmp);
            return result;
        }

        public SortedDictionary<K, V> Sorted<K, V>(IDictionary<K, V> other, IComparer<K> cmp)
        {
            return new SortedDictionary<K, V>(other, cmp);
        }

        public bool NotSuppressed(string nsName) {
            return !suppressedNamespaces.ContainsKey(nsName);
        }

        public void GenerateConfig() {
            XmlWriter w = OpenOut("config.xml");
            w.WriteStartDocument();
            w.WriteStartElement("options");
            w.WriteStartElement("option");
            w.WriteAttributeString("googlenonlocaltypes", googleNonlocalTypes ? "true" : "false");
            w.WriteEndElement();
            w.WriteEndElement();
            w.WriteEndDocument();
            w.Flush();
            w.Close();
        }

        public void Generate() {
            GenerateConfig();

            XmlWriter w = OpenOut("index.xml");
            w.WriteStartDocument();
            w.WriteStartElement("index");

            w.WriteStartElement("namespaces");
            foreach (var entry in Sorted(namespaces, StringComparer.InvariantCulture)) {
                string namespaceName = (string) entry.Key;
                if (NotSuppressed(namespaceName)) {
                    w.WriteStartElement("namespace");
                    w.WriteAttributeString("name", namespaceName);
                    WriteItemDocs(w, "N:"+namespaceName, "summary");
                    w.WriteEndElement();
                }
            }
            w.WriteEndElement();

            w.WriteStartElement("types");
            foreach (var entry in Sorted(types, StringComparer.InvariantCulture)) {
                Type t = (Type) entry.Value;
                if (NotSuppressed(Namespace(t))) {
                    w.WriteStartElement("typedoc");
                    GenerateTypeRef(w, t);
                    WriteItemDocs(w, t, "summary");
                    w.WriteEndElement();
                }
            }
            w.WriteEndElement();

            w.WriteEndElement();
            w.WriteEndDocument();
            w.Flush();
            w.Close();

            var typesToIterate = types.Values.ToList<Type>();
            typesToIterate.RemoveAll(t => t.FullName.Contains("<"));
            foreach (Type t in typesToIterate)
            {
                if (NotSuppressed(Namespace(t))) {
                    GenerateTypePage(t);
                }
            }

            foreach (var entry in namespaces) {
                string nsName = (string) entry.Key;
                if (NotSuppressed(nsName)) {
                    GenerateNamespacePage(nsName, (ArrayList) entry.Value);
                }
            }
        }

        public void GenerateTypePage(Type t) {
            var filename = "type-" + t.FullName + ".xml";
            Console.WriteLine("Generating page for type {0} at {1}", t.FullName, filename);
            XmlWriter w = OpenOut(filename);
            w.WriteStartDocument();
            w.WriteStartElement("typedef");
            WriteItemAttributes(w, t);
            GenerateTypeRef(w, t, true);
            Type[] nestedTypes = t.GetNestedTypes(LiberalFlags);
            if (nestedTypes.Length > 0) {
                w.WriteStartElement("nestedtypes");
                foreach (Type nested in nestedTypes) {
                    GenerateTypeRef(w, nested);
                }
                w.WriteEndElement();
            }
            w.WriteStartElement("extends");
            if (t.BaseType != null) {
                w.WriteStartElement("class");
                GenerateTypeRef(w, t.BaseType);
                w.WriteEndElement();
            }
            foreach (Type i in Sorted(GetDirectInterfaces(t), new MemberInfoNameComparer())) {
                w.WriteStartElement("interface");
                GenerateTypeRef(w, i);
                w.WriteEndElement();
            }
            w.WriteEndElement();
            w.WriteStartElement("known-subtypes");
            if (knownSubtypes.ContainsKey(t)) {
                ArrayList sts = (ArrayList) knownSubtypes[t];
                sts.Sort(new TypeComparer());
                foreach (Type st in sts) {
                    GenerateTypeRef(w, st);
                }
            }
            w.WriteEndElement();
            WriteItemDocs(w, t);
            w.WriteStartElement("members");
            foreach (FieldInfo fi
                     in Sorted(t.GetFields(LiberalFlags), new MemberInfoNameComparer())) {
                GenerateFieldDoc(w, fi);
            }
            foreach (PropertyInfo pi
                     in Sorted(t.GetProperties(LiberalFlags), new MemberInfoNameComparer())) {
                GeneratePropertyDoc(w, pi);
            }
            foreach (EventInfo ei
                     in Sorted(t.GetEvents(LiberalFlags), new MemberInfoNameComparer())) {
                GenerateEventDoc(w, ei);
            }
            var mbs = Sorted(t.GetConstructors(LiberalFlags), new MemberInfoNameComparer());
            foreach (MethodBase mi in mbs) {
                Console.WriteLine("\tProcessing method {0}", mi.Name);
                GenerateMethodDoc(w, mi);
            }
            foreach (MethodBase mi
                     in Sorted(t.GetMethods(LiberalFlags), new MemberInfoNameComparer())) {
                GenerateMethodDoc(w, mi);
            }
            w.WriteEndElement();
            w.WriteEndElement();
            w.WriteEndDocument();
            w.Flush();
            w.Close();
        }

	public string GenericBaseName(string n) {
	    return n.Split(new char[1] {'`'})[0];
	}

        public string MaybeInnerFullName(Type t) {
            return (t.FullName == null ? t.Name : t.FullName).Replace("+", ".");
        }

        public string ConcatNamespace(Type ptBase, string suffix) {
            if (ptBase.Namespace != null) {
                return ptBase.Namespace + "." + suffix;
            } else {
                return suffix;
            }
        }

	public void AppendTypeName(StringBuilder sb, Type pt) {
	    if (pt.IsGenericParameter) {
                if (pt.DeclaringMethod != null) {
                    sb.Append("``");
                } else {
                    sb.Append("`");
                }
                sb.Append(pt.GenericParameterPosition);
	    } else {
                if (pt.IsGenericType) {
                    Type ptBase = pt.GetGenericTypeDefinition();

                    // Match bugs in csc's documentation output.
                    // A generic type A.X+Y`1 comes out A.Y{T}
                    // A nongeneric type A.X+Y comes out A.X.Y
                    sb.Append(ConcatNamespace(ptBase, GenericBaseName(ptBase.Name)));

                    Type[] ptArgs = pt.GetGenericArguments();
                    if (ptArgs.Length > 0) {
                        sb.Append("{");
                        bool needComma = false;
                        foreach (Type ptArg in ptArgs) {
                            if (needComma) { sb.Append(","); }
                            needComma = true;
                            AppendTypeName(sb, ptArg);
                        }
                        sb.Append("}");
                    }
                } else {
                    sb.Append(GenericBaseName(MaybeInnerFullName(pt)));
                }
	    }
	}

        public string MethodFullName(MethodBase mi, string shortName) {
            StringBuilder sb = new StringBuilder();
            sb.Append(MaybeInnerFullName(mi.DeclaringType) + "." + shortName);
            if (mi.ContainsGenericParameters && !mi.IsConstructor) {
		        int genArgCount = mi.GetGenericArguments().Length;
		        if (genArgCount > 0) {
		            sb.Append("``");
		            sb.Append(genArgCount);
		        }
            }
            bool needComma = false;
            foreach (ParameterInfo pi in mi.GetParameters()) {
                if (needComma) {
                    sb.Append(",");
                } else {
                    sb.Append("(");
                    needComma = true;
                }
                if (pi.IsOut || pi.ParameterType.IsByRef) {
                    AppendTypeName(sb, pi.ParameterType.GetElementType());
                    sb.Append("@");
                } else {
                    AppendTypeName(sb, pi.ParameterType);
                }
            }
            if (needComma) {
                sb.Append(")");
            }
            return sb.ToString();
        }

        public string MemberFullName(MemberInfo mi) {
            if (mi is Type) {
		Type t = (Type) mi;
		return MaybeInnerFullName(t);
            } else if (mi is MethodInfo) {
                return MethodFullName((MethodBase) mi, mi.Name);
            } else if (mi is ConstructorInfo) {
                return MethodFullName((MethodBase) mi, "#ctor");
            } else {
                return MaybeInnerFullName(mi.DeclaringType) + "." + mi.Name;
            }
        }

        public void GenerateMethodDoc(XmlWriter w, MethodBase mi) {
            w.WriteStartElement("method");
            WriteItemAttributes(w, mi);
            GenerateGenericArguments(w, mi);
            if (mi is MethodInfo) {
                w.WriteStartElement("returns");
                GenerateTypeRef(w, ((MethodInfo) mi).ReturnType);
                w.WriteEndElement();
            } else if (mi is ConstructorInfo) {
                w.WriteStartElement("constructor");
                w.WriteEndElement();
            } else {
                throw new Exception("Unsupported MethodBase: " + mi);
            }
            w.WriteStartElement("parameters");
            foreach (ParameterInfo pi in mi.GetParameters()) {
                w.WriteStartElement("parameter");
                w.WriteAttributeString("name", pi.Name);
                w.WriteAttributeString("input", pi.IsIn ? "true" : "false");
                w.WriteAttributeString("output", pi.IsOut ? "true" : "false");
                w.WriteAttributeString("reference", ((!pi.IsOut) && pi.ParameterType.IsByRef) ? "true" : "false");
                w.WriteAttributeString("position", pi.Position.ToString());
                if (pi.IsOut || pi.ParameterType.IsByRef) {
                    GenerateTypeRef(w, pi.ParameterType.GetElementType());
                } else {
                    GenerateTypeRef(w, pi.ParameterType);
                }
                w.WriteEndElement();
            }
            w.WriteEndElement();
            WriteItemDocs(w, mi);
            w.WriteEndElement();
        }

        public void GenerateFieldDoc(XmlWriter w, FieldInfo fi) {
            w.WriteStartElement("field");
            WriteItemAttributes(w, fi);
            GenerateTypeRef(w, fi.FieldType);
            WriteItemDocs(w, fi);
            w.WriteEndElement();
        }

        public void GeneratePropertyDoc(XmlWriter w, PropertyInfo pi) {
            w.WriteStartElement("property");
            WriteItemAttributes(w, pi);
            GenerateTypeRef(w, pi.PropertyType);
            WriteItemDocs(w, pi);
            if (pi.CanRead) {
                w.WriteStartElement("getter");
                WriteItemAttributes(w, pi.GetGetMethod(true));
                w.WriteEndElement();
            }
            if (pi.CanWrite) {
                w.WriteStartElement("setter");
                WriteItemAttributes(w, pi.GetSetMethod(true));
                w.WriteEndElement();
            }
            w.WriteEndElement();
        }

        public void GenerateEventDoc(XmlWriter w, EventInfo ei) {
            w.WriteStartElement("event");
            WriteItemAttributes(w, ei);
            GenerateTypeRef(w, ei.EventHandlerType);
            WriteItemDocs(w, ei);
            w.WriteEndElement();
        }

        public sealed class TypeComparer: IComparer {
            int IComparer.Compare(Object a, Object b) {
                return ((Type) a).FullName.CompareTo(((Type) b).FullName);
            }
        }

        public void GenerateNamespacePage(string namespaceName, ArrayList types) {
            types.Sort(new TypeComparer());
            XmlWriter w = OpenOut("namespace-"+namespaceName+".xml");
            w.WriteStartDocument();
            w.WriteStartElement("namespace");
            w.WriteAttributeString("name", namespaceName);
            WriteItemDocs(w, "N:"+namespaceName);
            foreach (Type t in Sorted(types, new MemberInfoNameComparer())) {
                w.WriteStartElement("typedoc");
                GenerateTypeRef(w, t);
                WriteItemDocs(w, t, "summary");
                w.WriteEndElement();
            }
            w.WriteEndElement();
            w.WriteEndDocument();
            w.Flush();
            w.Close();
        }

        public void WriteItemAttributes(XmlWriter w, MemberInfo mi) {
            w.WriteAttributeString("anchor", KeyForMember(mi));
            w.WriteAttributeString("leaf",
                                   (mi is ConstructorInfo)
                                   ? GenericBaseName(mi.DeclaringType.Name)
                                   : GenericBaseName(mi.Name));
            w.WriteAttributeString("fullname", MemberFullName(mi));
            w.WriteAttributeString("namespace",
                                   (mi is Type)
                                   ? Namespace((Type) mi)
                                   : Namespace(mi.DeclaringType));
            if (mi is Type) {
                Type x = (Type) mi;
                if (x.IsAbstract) { w.WriteAttributeString("abstract", "true"); }
                if (x.IsClass) { w.WriteAttributeString("class", "true"); }
                if (x.IsEnum) { w.WriteAttributeString("enum", "true"); }
		if (x.IsGenericParameter) {
		    w.WriteAttributeString("generictypeparameter", "true");
		    w.WriteAttributeString("genericparameterposition",
					   x.GenericParameterPosition.ToString());
		}
		if (x.IsGenericType) { w.WriteAttributeString("generictype", "true"); }
		if (x.IsGenericTypeDefinition) { w.WriteAttributeString("generictypedefinition", "true"); }
                if (x.IsInterface) { w.WriteAttributeString("interface", "true"); }
                if (x.IsPublic) { w.WriteAttributeString("public", "true"); }
                if (x.IsSpecialName) { w.WriteAttributeString("specialname", "true"); }
                if (x.IsValueType) { w.WriteAttributeString("valuetype", "true"); }
                // if (x.IsVisible) { w.WriteAttributeString("visible", "true"); }
            } else if (mi is FieldInfo) {
                FieldInfo x = (FieldInfo) mi;
                if (x.IsAssembly) { w.WriteAttributeString("assembly", "true"); }
                if (x.IsFamily) { w.WriteAttributeString("family", "true"); }
                if (x.IsInitOnly) { w.WriteAttributeString("initonly", "true"); }
                if (x.IsLiteral) { w.WriteAttributeString("literal", "true"); }
                if (x.IsPrivate) { w.WriteAttributeString("private", "true"); }
                if (x.IsPublic) { w.WriteAttributeString("public", "true"); }
                if (x.IsSpecialName) { w.WriteAttributeString("specialname", "true"); }
                if (x.IsStatic) { w.WriteAttributeString("static", "true"); }
            } else if (mi is PropertyInfo) {
                PropertyInfo x = (PropertyInfo) mi;
                if (x.IsSpecialName) { w.WriteAttributeString("specialname", "true"); }
            } else if (mi is EventInfo) {
                EventInfo x = (EventInfo) mi;
                if (x.IsMulticast) { w.WriteAttributeString("multicast", "true"); }
                if (x.IsSpecialName) { w.WriteAttributeString("specialname", "true"); }
            } else if (mi is MethodBase) {
                MethodBase x = (MethodBase) mi;
                if (x.IsAbstract) { w.WriteAttributeString("abstract", "true"); }
                if (x.IsAssembly) { w.WriteAttributeString("assembly", "true"); }
                if (x.IsConstructor) { w.WriteAttributeString("constructor", "true"); }
                if (x.IsFamily) { w.WriteAttributeString("family", "true"); }
                if (x.IsFinal) { w.WriteAttributeString("final", "true"); }
                if (x.IsPrivate) { w.WriteAttributeString("private", "true"); }
                if (x.IsPublic) { w.WriteAttributeString("public", "true"); }
                if (x.IsSpecialName) { w.WriteAttributeString("specialname", "true"); }
                if (x.IsStatic) { w.WriteAttributeString("static", "true"); }
                if (x.IsVirtual) { w.WriteAttributeString("virtual", "true"); }
            }
        }

        public string KeyForMember(MemberInfo mi) {
            if (mi is FieldInfo) return "F:" + MemberFullName(mi);
            if (mi is PropertyInfo) return "P:" + MemberFullName(mi);
            if (mi is EventInfo) return "E:" + MemberFullName(mi);
            if (mi is MethodBase) return "M:" + MemberFullName(mi);
            if (mi is Type) return "T:" + MemberFullName(mi);
            throw new Exception("Unsupported member kind: " + mi.ToString() + ", " + mi.GetType().ToString());
        }

        public void WriteItemDocs(XmlWriter w, MemberInfo mi) {
            String key = KeyForMember(mi);
            WriteItemDocs(w, key);
        }

        public void WriteItemDocs(XmlWriter w, MemberInfo mi, string subsetSpec) {
            String key = KeyForMember(mi);
            WriteItemDocs(w, key, subsetSpec);
        }

        public void WriteItemDocs(XmlWriter w, string key) {
            WriteItemDocs(w, key, "*");
        }

        public void WriteItemDocs(XmlWriter w, string key, string subsetSpec) {
            w.WriteStartElement("doc");
            if (members.ContainsKey(key)) {
                XmlNode node = (XmlNode) members[key];
                foreach (XmlNode n in node.SelectNodes(subsetSpec)) {
                    w.WriteRaw(n.OuterXml);
                }
            }
            w.WriteEndElement();
        }

        public bool IsIndirect(Type t) {
            return t.IsArray || t.IsByRef;
        }

	public bool IsLocal(Type t) {
	    Type pt = t.IsGenericType ? t.GetGenericTypeDefinition() : t;
	    return
		(types.ContainsKey(pt.FullName) && NotSuppressed(Namespace(pt)))
                || (IsIndirect(pt) && IsLocal(pt.GetElementType()));
	}

	public void GenerateGenericArguments(XmlWriter w, Type t, bool emitTypeConstraints) {
	    Type[] genericArguments = t.GetGenericArguments();
            int outerGenericArgumentCount =
                (t.DeclaringType == null) ? 0 : t.DeclaringType.GetGenericArguments().Length;
            GenerateGenericArguments(w,
                                     genericArguments,
                                     outerGenericArgumentCount,
                                     emitTypeConstraints);
        }

	public void GenerateGenericArguments(XmlWriter w, MethodBase mi) {
            if (mi.ContainsGenericParameters && !mi.IsConstructor) {
                GenerateGenericArguments(w,
                                         mi.GetGenericArguments(),
                                         0,
                                         false);
            }
        }

	public void GenerateGenericArguments(XmlWriter w,
                                             Type[] genericArguments,
                                             int startOffset,
                                             bool emitTypeConstraints)
        {
            bool needEndElement = false;
            for (int i = startOffset; i < genericArguments.Length; i++) {
                Type genericArgument = genericArguments[i];
                if (!needEndElement) {
                    w.WriteStartElement("genericarguments");
                    needEndElement = true;
                }
                GenerateTypeRef(w, genericArgument, emitTypeConstraints);
            }
            if (needEndElement) {
                w.WriteEndElement();
            }
	}

        public void GenerateTypeRef(XmlWriter w, Type t) {
	    GenerateTypeRef(w, t, false);
	}

        public void GenerateTypeRef(XmlWriter w, Type t, bool emitTypeConstraints) {
            GenerateTypeRef(w, t, "", emitTypeConstraints);
        }

        public void GenerateTypeRef(XmlWriter w, Type t, string referenceChain, bool emitTypeConstraints)
        {
            if (t.IsArray) {
                GenerateTypeRef(w, t.GetElementType(), referenceChain + "A", emitTypeConstraints);
                return;
            } else if (t.IsByRef) {
                GenerateTypeRef(w, t.GetElementType(), referenceChain + "R", emitTypeConstraints);
                return;
            }

	    Type baseType = t.IsGenericType ? t.GetGenericTypeDefinition() : t;
            w.WriteStartElement("type");
            w.WriteAttributeString("name", baseType.FullName);
            w.WriteAttributeString("referenceChain", referenceChain);
            w.WriteAttributeString("leaf", GenericBaseName(baseType.Name));
            w.WriteAttributeString("namespace", Namespace(baseType));
            w.WriteAttributeString("local",
				   t.IsGenericParameter ? "genericparameter" :
				   IsLocal(t) ? "true" :
				   "false");
	    w.WriteAttributeString("generictype", t.IsGenericType ? "true" : "false");
	    w.WriteAttributeString("generictypedefinition", t.IsGenericTypeDefinition ? "true" : "false");
	    w.WriteAttributeString("genericparameter", t.IsGenericParameter ? "true" : "false");
	    if (t.IsGenericParameter) {
                if (t.DeclaringMethod != null) {
                    w.WriteAttributeString("methodgenericparameter", "true");
                }
		w.WriteAttributeString("genericparameterposition",
				       t.GenericParameterPosition.ToString());
		if (emitTypeConstraints) {
		    GenerateTypeConstraints(w, t);
		}
	    } else {
                if (t.DeclaringType != null) {
                    w.WriteStartElement("declaringtype");
                    GenerateTypeRef(w, t.DeclaringType);
                    w.WriteEndElement();
                }
            }
	    GenerateGenericArguments(w, t, emitTypeConstraints);
            w.WriteEndElement();
        }

	public void GenerateTypeConstraints(XmlWriter w, Type t) {
	    w.WriteStartElement("typeconstraints");

	    GenericParameterAttributes gpa = t.GenericParameterAttributes;
	    if ((gpa & GenericParameterAttributes.NotNullableValueTypeConstraint) != 0) {
		w.WriteElementString("notnullablevaluetype", "");
	    }
	    if ((gpa & GenericParameterAttributes.ReferenceTypeConstraint) != 0) {
		w.WriteElementString("referencetype", "");
	    }

	    Type[] typeConstraints = t.GetGenericParameterConstraints();
	    if (typeConstraints.Length > 0) {
		foreach (Type constraint in typeConstraints) {
		    GenerateTypeRef(w, constraint);
		}
	    }

	    if ((gpa & GenericParameterAttributes.DefaultConstructorConstraint) != 0) {
		w.WriteElementString("defaultconstructor", "");
	    }

	    w.WriteEndElement();
	}

        public BindingFlags LiberalFlags {
            get {
                BindingFlags f = 
                    BindingFlags.Instance
                    | BindingFlags.Static
                    | BindingFlags.Public
                    | BindingFlags.DeclaredOnly;
                if (includeNonpublic) {
                    f = f | BindingFlags.NonPublic;
                }
                return f;
            }
        }
    }
}
