namespace net.lshift.ndocproc.examples.genericdelegates
{
    using System;

    ///<summary>Foo delegate</summary>
    internal delegate void Foo(TimeSpan timeout);

    ///<summary>Generic foo delegate</summary>
    internal delegate TResult Foo<TResult>(TimeSpan timeout);

    ///<summary>Variant one</summary>
    internal delegate TResult Foo1<TResult, TArg>(TimeSpan timeout, TArg arg0);

    ///<summary>Variant two</summary>
    internal delegate TResult Foo2<TResult, TArg>(TimeSpan timeout, out TArg arg0);
 
    ///<summary>Variant three</summary>
    internal delegate TResult Foo3<TResult, TArg>(TimeSpan timeout, ref TArg arg0);

    ///<summary>Variant four</summary>
    internal delegate TResult Foo4<TResult, TArg>(TimeSpan timeout, TArg[] arg0);

    ///<summary>Variant five</summary>
    internal delegate TResult Foo5<TResult, TArg>(TimeSpan timeout, out TArg[] arg0);

    ///<summary>Variant six</summary>
    internal delegate TResult Foo6<TResult, TArg>(TimeSpan timeout, ref TArg[] arg0);

    ///<summary>Bar delegate</summary>
    internal delegate void Bar(object message, TimeSpan timeout);
}