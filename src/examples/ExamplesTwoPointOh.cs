namespace net.lshift.ndocproc.examples.twopointoh {
    using System;

    ///<summary>Code examples from
    ///http://msdn2.microsoft.com/en-us/library/ms379564(vs.80).aspx</summary>
    public class Node<K,T>: ICloneable
	where K: struct, IComparable<K>
	where T: class, new()
    {
	///<summary>Key field</summary>
	public K Key;

	///<summary>Item field</summary>
	public T Item;

	///<summary>Link to next element in list</summary>
	public Node<K,T> NextNode;

	///<summary>Default ctor</summary>
	public Node()
	{
	    Key      = default(K);
	    Item     = new T();
	    NextNode = null;
	}

	///<summary>Full ctor</summary>
	public Node(K key,T item,Node<K,T> nextNode)
	{
	    Key      = key;
	    Item     = item;
	    NextNode = nextNode;
	}

	///<summary>Implement ICloneable.Clone by delegating to our type-safe variant.</summary>
	///<remarks>
	/// MCS (and possibly CSC also) is buggy. The emitted
	/// documentation XML file refers to this method as
	/// M:net.lshift.ndocproc.examples.twopointoh.Node`2.System.ICloneable.Clone
	/// when implemented as System.ICloneable.Clone (in so many
	/// words), and as
	/// M:net.lshift.ndocproc.examples.twopointoh.Node`2.ICloneable.Clone
	/// when implemented as ICloneable.Clone. It shouldn't matter
	/// which name it's implemented under - the compiler should
	/// fully-qualify the method name before emitting the
	/// documentation XML - but since there's no clean way of
	/// guessing the actual identifier used by the author of a
	/// piece of code (other than perhaps laboriously guessing and
	/// checking against the actual emitted XML), NDocProc ignores
	/// the problem and relies on code authors to write the
	/// fully-qualified names in order to find the appropriate
	/// documentation stanza.
	///</remarks>
	object System.ICloneable.Clone() {
	    return ((Node<K,T>) this).Clone();
	}

	///<summary>Typesafe clone.</summary>
	public Node<K,T> Clone() {
	    Node<K,T> n = this.MemberwiseClone() as Node<K,T>;
	    return n;
	}
    }

    public class Dummy {
        public Dummy() {}
    }

    ///<summary>I am a linked list</summary>
    ///<remarks>
    ///<para>
    /// Type K is ...
    ///</para>
    ///<para>
    /// Type T is ...
    ///</para>
    ///</remarks>
    public class LinkedList<K> where K: struct, IComparable<K>
    {
	///<summary>Head of the list</summary>
	Node<K,Dummy> m_Head;

	///<summary>Creates an empty list</summary>
	public LinkedList()
	{
	    m_Head = new Node<K,Dummy>();
	}

	///<summary>Inserts an element at the head of the list</summary>
	public void AddHead(K key,Dummy item)
	{
	    Node<K,Dummy> newNode = new Node<K,Dummy>(key,item,m_Head.NextNode);
	    m_Head.NextNode = newNode;
	}

	///<summary>This has bizarre generic types in it</summary>
	public void Odd(Node<K,Node<K,Dummy>> something) {
	}
    }
}
