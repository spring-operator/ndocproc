using net.lshift.ndocproc;

namespace net.lshift.ndocproc.examples.interfaces {
    ///<summary>First interface</summary>
    public interface I1 {
	///<summary>Nullary from I1</summary>
	object Nullary();
	///<summary>UnarySpecific from I1</summary>
	object UnarySpecific(I1 x);
	///<summary>UnaryGeneric from I1</summary>
	object UnaryGeneric(object x);
    }

    ///<summary>Second interface</summary>
    public interface I2 {
	///<summary>Nullary from I2</summary>
	object Nullary();
	///<summary>UnarySpecific from I2</summary>
	object UnarySpecific(I2 x);
	///<summary>UnaryGeneric from I2</summary>
	object UnaryGeneric(object x);
    }

    ///<summary>Implements both interfaces simply.</summary>
    public class C12A: I1, I2 {
	///<summary>Nullary from I1, I2</summary>
	public object Nullary() {
	    return null;
	}

	///<summary>UnarySpecific from I1</summary>
	public object UnarySpecific(I1 x) {
	    return x;
	}

	///<summary>UnarySpecific from I2</summary>
	public object UnarySpecific(I2 x) {
	    return x;
	}

	///<summary>UnaryGeneric from I1, I2</summary>
	public object UnaryGeneric(object x) {
	    return x;
	}
    }

    ///<summary>Implements both interfaces separately.</summary>
    public class C12B: I1, I2 {
	///<summary>Nullary from I1</summary>
	object examples.interfaces.I1.Nullary() {
	    return null;
	}

	///<summary>Nullary from I2</summary>
	object I2.Nullary() {
	    return null;
	}

	///<summary>UnarySpecific from I1</summary>
	public object UnarySpecific(I1 x) {
	    return x;
	}

	///<summary>UnarySpecific from I2</summary>
	public object UnarySpecific(I2 x) {
	    return x;
	}

	///<summary>UnaryGeneric from I1</summary>
	object net.lshift.ndocproc.examples.interfaces.I1.UnaryGeneric(object x) {
	    return x;
	}

	///<summary>UnaryGeneric from I2</summary>
	object I2.UnaryGeneric(object x) {
	    return x;
	}
    }
}