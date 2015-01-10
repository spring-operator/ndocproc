namespace net.lshift.ndocproc.examples.suppressed {
    ///<summary>ShouldNotAppear documentation</summary>
    public abstract class ShouldNotAppear {
        ///<summary>ShouldNotAppear.Operation documentation</summary>
        public abstract int Operation(int arg1, int arg2);
    }
}

namespace net.lshift.ndocproc.examples.notsuppressed {
    ///<summary>ShouldNotAppear documentation</summary>
    public abstract class ShouldAppear {
        ///<summary>The link to ShouldNotAppear shouldn't be a local link</summary>
        public abstract int Operation(net.lshift.ndocproc.examples.suppressed.ShouldNotAppear arg);
    }
}
