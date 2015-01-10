using System.Net;

namespace net.lshift.ndocproc.examples.one {
    ///<summary>Donec laoreet arcu lobortis sem. Mauris
    ///elementum. Aenean feugiat magna vitae urna. Cras
    ///posuere. Vestibulum nec risus. Duis et erat. In
    ///purus. Aliquam sed est. Maecenas molestie lacus id
    ///arcu. Duis nibh. Praesent arcu est.</summary>
    ///
    ///<remarks>
    ///
    ///<para>Lorem ipsum dolor sit amet, consectetuer adipiscing
    ///elit. Ut interdum aliquet quam. Donec metus turpis, luctus ut,
    ///eleifend ut, porttitor ut, arcu. Maecenas nisl massa, vulputate
    ///ac, euismod vitae, dapibus vitae, dolor. Praesent ipsum. Donec
    ///vitae pede vitae neque suscipit auctor. Pellentesque odio est,
    ///sagittis sit amet, mollis in, sollicitudin quis,
    ///lacus. Pellentesque tortor sem, adipiscing eu, faucibus vel,
    ///elementum sed, justo. Nullam consequat diam nec purus. Praesent
    ///nec justo. In vitae mi. Phasellus eget arcu. Nulla ac velit ut
    ///tortor iaculis pulvinar. Etiam vitae sem. Duis fringilla
    ///faucibus quam. Nam magna massa, sodales imperdiet, rutrum vel,
    ///hendrerit malesuada, nibh. Vivamus euismod. Phasellus nisl leo,
    ///auctor a, placerat et, vehicula quis, tellus. Quisque vel
    ///sapien. Ut imperdiet.</para>
    ///
    ///<para>Donec sed metus. Integer euismod, odio eu consectetuer
    ///lacinia, arcu mi pulvinar sapien, at vehicula neque nunc quis
    ///lorem. Suspendisse varius tempus dui. Suspendisse porta neque
    ///eget pede accumsan cursus. Nam nec eros. Nunc sem turpis,
    ///tincidunt id, adipiscing at, blandit eu, pede. Sed dolor. Donec
    ///eget augue. Integer placerat blandit diam. Ut non lorem quis
    ///lectus dictum semper. Cras vitae turpis at leo lacinia
    ///porttitor. Phasellus sed dolor. Nullam ligula dui, congue ut,
    ///fringilla elementum, pretium ac, metus. Nam sem. Fusce tempor
    ///accumsan nunc. Proin metus turpis, luctus vitae, lobortis at,
    ///porttitor eu, urna. Sed sit amet felis eget tellus pellentesque
    ///euismod. In hac habitasse platea dictumst. Etiam luctus.</para>
    ///
    ///<para>Maecenas pretium neque convallis mi. Nulla massa. Nullam
    ///in mi. Sed interdum. Integer quis erat in velit eleifend
    ///volutpat. Praesent dolor metus, pulvinar ut, pharetra ac,
    ///molestie nec, diam. In cursus interdum velit. Pellentesque
    ///lacus nulla, faucibus non, ullamcorper et, sollicitudin a,
    ///turpis. Donec id diam ac nisl adipiscing laoreet. Maecenas eget
    ///justo a quam tincidunt suscipit. Etiam interdum consectetuer
    ///enim. Praesent imperdiet. Duis imperdiet lectus non
    ///massa. Mauris laoreet nisi ac ante. Pellentesque tristique
    ///lectus quis neque. Nulla egestas consequat urna.</para>
    ///
    ///<example><code>
    /// Example line 1
    /// Example line 2
    /// // a comment on line 3
    /// Example line 4
    ///</code></example>
    ///
    ///</remarks>
    public class OneHello {
        ///<summary>In iaculis condimentum pede. Pellentesque vitae
        ///nulla. Aenean ullamcorper. Curabitur sed elit eu nulla.
        ///</summary><remarks>luctus adipiscing. Sed eget quam vitae augue lacinia
        ///molestie. Donec dignissim auctor lorem. Ut ac
        ///nibh. Pellentesque habitant morbi tristique senectus et
        ///netus et malesuada fames ac turpis egestas. Aliquam
        ///faucibus nonummy dolor. Sed feugiat dapibus diam. Vivamus
        ///eget lectus. Proin pharetra lacus sit amet nisi. Curabitur
        ///ullamcorper fermentum turpis. Donec nisl velit, luctus nec,
        ///pharetra a, pretium et, mi.</remarks>
        public const int AA = 123;

        ///<summary>Proin nibh. Donec dui odio, malesuada ac,
        ///tristique ut, tempus eu, elit. Duis egestas risus sed.
        ///</summary><remarks>metus. Aliquam ullamcorper. In hac habitasse platea
        ///dictumst. Mauris vel ante. Curabitur diam elit, ornare sed,
        ///commodo in, ornare rutrum, ante. Nunc nibh arcu, pretium
        ///et, aliquam eget, laoreet eu, odio. Curabitur volutpat, leo
        ///ut auctor facilisis, mauris justo consequat ante, eu
        ///adipiscing metus diam at libero. Fusce accumsan sapien nec
        ///purus. Vivamus sagittis. Cras massa orci, euismod id,
        ///blandit eu, blandit eget, tellus. Phasellus risus. Maecenas
        ///nonummy aliquam orci. Curabitur fermentum pede et mi. Ut
        ///aliquet. Nulla quis erat vitae odio blandit
        ///faucibus. Integer eros felis, gravida in, imperdiet a,
        ///blandit non, sapien. Vivamus vulputate dui bibendum
        ///nisl. Curabitur est ligula, eleifend eget, porta eu,
        ///convallis at, orci.</remarks>
        protected const string BB = "hello";

        ///<summary>Aliquam erat volutpat. Sed rhoncus. Maecenas massa
        ///nunc, facilisis sed, rutrum vel, tincidunt a, lectus. Donec.
        ///</summary><remarks>ipsum. Lorem ipsum dolor sit amet, consectetuer adipiscing
        ///elit. Sed placerat eros ac dui. In hac habitasse platea
        ///dictumst. Phasellus mauris purus, congue a, sagittis nec,
        ///faucibus at, nunc. Morbi bibendum magna nec
        ///nisi. Suspendisse libero. Etiam ut nisi. Nunc tempor, nulla
        ///id posuere feugiat, lacus libero consectetuer odio, ut
        ///laoreet quam ipsum at risus. Donec egestas. Maecenas
        ///interdum, libero eget blandit ultrices, nisl leo molestie
        ///quam, a rhoncus enim lacus ut enim. Vestibulum ligula erat,
        ///tincidunt eget, porta nec, volutpat vel, arcu.</remarks>
        private const double CC = 456.789;


        ///<summary>Suspendisse ultrices commodo nunc. Nulla hendrerit
        ///enim ac ante. Cum sociis natoque penatibus et magnis dis.
        ///</summary><remarks>parturient montes, nascetur ridiculus mus. Curabitur in
        ///lectus sit amet odio accumsan ultricies. Pellentesque
        ///convallis tellus in neque. Nulla sed dolor. Sed a tortor
        ///nec augue venenatis condimentum. Duis interdum ligula vitae
        ///nunc. Etiam tincidunt sodales ligula. Ut ultricies
        ///mauris. Vestibulum pharetra lacus id massa. Sed convallis
        ///enim nec dolor. Nunc rhoncus est at leo. Pellentesque
        ///suscipit nisl vitae velit. Ut porttitor iaculis
        ///risus. Praesent leo. Quisque pellentesque consectetuer
        ///lectus. Integer sed nisi. Nulla tempus, odio sed
        ///condimentum consequat, odio metus viverra orci, sed
        ///facilisis orci odio in sem.</remarks>
        public static int s_m_A = 123;

        ///<summary>Duis pellentesque imperdiet dui. Vestibulum in
        ///purus. Proin eu risus tempus leo aliquet ullamcorper. Cras.
        ///</summary><remarks>nulla. Ut eu dolor euismod erat laoreet aliquet. Maecenas
        ///pharetra condimentum dui. In hac habitasse platea
        ///dictumst. In venenatis accumsan massa. Duis nec
        ///risus. Mauris dolor felis, lacinia et, tincidunt in,
        ///feugiat nec, felis. Fusce at leo sed quam congue
        ///egestas. Donec velit tellus, fringilla eu, vestibulum sed,
        ///vulputate at, lorem. Curabitur arcu risus, molestie eu,
        ///pellentesque ut, sodales at, nisi. Ut tempor massa et
        ///enim. Ut aliquet.</remarks>
        protected static string s_m_B = "hello";

        ///<summary>Ut a elit in orci lobortis bibendum. Donec
        ///pretium, eros id feugiat aliquet, nulla pede nonummy.
        ///</summary><remarks>tortor, vel mattis nunc lacus in purus. Ut nec quam non
        ///enim rutrum commodo. Proin erat orci, tempus semper,
        ///suscipit in, commodo et, ligula. Mauris sit amet
        ///erat. Pellentesque consequat, sapien eget condimentum
        ///feugiat, lorem lectus porta sem, eu eleifend ligula lacus
        ///ac nulla. Quisque mattis, ipsum ut vehicula placerat, dolor
        ///neque feugiat sapien, a tempor metus sapien vitae
        ///odio. Nulla tincidunt. Vestibulum ante ipsum primis in
        ///faucibus orci luctus et ultrices posuere cubilia Curae;
        ///Donec iaculis mattis justo. In hac habitasse platea
        ///dictumst. Sed nunc orci, scelerisque a, euismod
        ///sollicitudin, viverra a, dolor. Nunc nunc arcu, vehicula
        ///eget, consectetuer vulputate, consequat at, nisi. Phasellus
        ///at odio. In mi tortor, aliquet eget, ultrices ac, iaculis
        ///at, neque. Etiam ornare ultricies purus. Nullam vestibulum
        ///cursus tellus. In vitae lectus vitae eros malesuada
        ///tempor. Proin vitae turpis a tortor lobortis
        ///eleifend.</remarks>
        private static double s_m_C = 456.789;


        ///<summary>Sed varius, risus et laoreet nonummy, libero dolor
        ///aliquam ligula, consequat rutrum sapien urna at nibh. Nulla.
        ///</summary><remarks>nunc arcu, laoreet ac, dignissim eu, eleifend sed,
        ///pede. Nulla purus. Sed et risus. Sed ac diam sed neque
        ///ultrices imperdiet. Aliquam leo. Praesent suscipit mollis
        ///augue. Suspendisse faucibus dignissim justo. Nam rutrum
        ///turpis. Class aptent taciti sociosqu ad litora torquent per
        ///conubia nostra, per inceptos hymenaeos. Nulla vel
        ///turpis. Donec ullamcorper risus a libero. Donec arcu felis,
        ///feugiat in, pellentesque non, convallis venenatis,
        ///justo. Integer quis justo. Quisque condimentum pellentesque
        ///nisl. Ut ac lorem id purus consectetuer commodo.</remarks>
        public int SA { get { return s_m_A; } }

        ///<summary>Cras tempus, mi quis facilisis fringilla, odio
        ///justo vehicula lorem, et aliquam massa nunc nec nisi. Cras.
        ///</summary><remarks>dapibus velit vitae tortor. Mauris pharetra lacus sit amet
        ///dolor. In erat. Aliquam posuere odio eget nisl. Fusce non
        ///augue. Aenean pharetra ipsum et enim. Sed at enim. Maecenas
        ///metus quam, varius sed, ultrices in, hendrerit ut,
        ///eros. Fusce turpis. Nullam facilisis. Praesent massa purus,
        ///consequat sit amet, rutrum posuere, adipiscing eget,
        ///magna. Pellentesque habitant morbi tristique senectus et
        ///netus et malesuada fames ac turpis egestas. Nullam
        ///sagittis. Cras eget nunc a orci ornare laoreet. Ut tellus
        ///dui, vulputate ut, dictum mattis, ultrices vel, risus. Ut
        ///nunc nulla, elementum sit amet, feugiat sit amet, sagittis
        ///a, nunc. Aenean mattis venenatis dui. Aenean est.</remarks>
        protected string SB { get { return s_m_B; } set { s_m_B = value; }  }

        ///<summary>Pellentesque tempor consequat eros. Suspendisse
        ///aliquet ante eu mi. Duis vitae massa. Pellentesque vitae.
        ///</summary><remarks>urna vitae leo consequat vestibulum. Maecenas vitae erat
        ///sed mauris scelerisque facilisis. Sed eu dui. Aliquam
        ///aliquet diam ut turpis. Fusce ultricies dictum
        ///velit. Pellentesque vel libero sed mauris semper
        ///lacinia. Mauris accumsan, quam at ultrices mollis, nisi
        ///turpis sollicitudin purus, ac fermentum mauris quam eu
        ///libero. Duis suscipit magna eget enim. Nullam urna risus,
        ///interdum eget, viverra vitae, malesuada vitae,
        ///elit. Maecenas in sapien eu velit ornare mollis. Aenean
        ///nibh risus, viverra at, malesuada sit amet, pharetra quis,
        ///metus. Pellentesque feugiat, justo convallis adipiscing
        ///dictum, nisi eros sodales nisi, sit amet vulputate nunc
        ///tellus nec leo. Class aptent taciti sociosqu ad litora
        ///torquent per conubia nostra, per inceptos hymenaeos. Morbi
        ///tortor arcu, convallis id, facilisis eu, ultrices et,
        ///nisi. Praesent ut nulla vitae massa consequat semper. Morbi
        ///fringilla orci nec mauris. Nullam sed orci eget nunc luctus
        ///molestie.</remarks>
        private double SC { get { return s_m_C; } set { s_m_C = value; } }


        ///<summary>Suspendisse potenti. Etiam consectetuer ante eu
        ///dui. Etiam semper. Aliquam vel nulla vel lorem lacinia.
        ///</summary><remarks>congue. Class aptent taciti sociosqu ad litora torquent per
        ///conubia nostra, per inceptos hymenaeos. Sed ante diam,
        ///laoreet at, vehicula ut, auctor vitae, justo. Lorem ipsum
        ///dolor sit amet, consectetuer adipiscing elit. Vestibulum
        ///cursus, erat quis mollis luctus, est leo semper felis,
        ///vitae egestas arcu tellus consequat metus. Aenean bibendum
        ///sem non neque. Quisque libero lacus, imperdiet eu,
        ///ullamcorper scelerisque, euismod feugiat, magna. In
        ///ultricies, turpis at facilisis imperdiet, augue ligula
        ///bibendum risus, id tincidunt nisi turpis eget
        ///elit. Maecenas dictum neque at mi. Nam quis nibh. Nullam
        ///ligula turpis, pharetra vel, ornare at, cursus eget,
        ///enim.</remarks>
        static OneHello() {
            StaticMethodC();
        }


        ///<summary>In iaculis condimentum pede. Pellentesque vitae
        ///nulla. Aenean ullamcorper. Curabitur sed elit eu nulla.
        ///</summary><remarks>luctus adipiscing. Sed eget quam vitae augue lacinia
        ///molestie. Donec dignissim auctor lorem. Ut ac
        ///nibh. Pellentesque habitant morbi tristique senectus et
        ///netus et malesuada fames ac turpis egestas. Aliquam
        ///faucibus nonummy dolor. Sed feugiat dapibus diam. Vivamus
        ///eget lectus. Proin pharetra lacus sit amet nisi. Curabitur
        ///ullamcorper fermentum turpis. Donec nisl velit, luctus nec,
        ///pharetra a, pretium et, mi.</remarks>
        public static void StaticMethodA() {}

        ///<summary>Proin nibh. Donec dui odio, malesuada ac,
        ///tristique ut, tempus eu, elit. Duis egestas risus sed.
        ///</summary><remarks>metus. Aliquam ullamcorper. In hac habitasse platea
        ///dictumst. Mauris vel ante. Curabitur diam elit, ornare sed,
        ///commodo in, ornare rutrum, ante. Nunc nibh arcu, pretium
        ///et, aliquam eget, laoreet eu, odio. Curabitur volutpat, leo
        ///ut auctor facilisis, mauris justo consequat ante, eu
        ///adipiscing metus diam at libero. Fusce accumsan sapien nec
        ///purus. Vivamus sagittis. Cras massa orci, euismod id,
        ///blandit eu, blandit eget, tellus. Phasellus risus. Maecenas
        ///nonummy aliquam orci. Curabitur fermentum pede et mi. Ut
        ///aliquet. Nulla quis erat vitae odio blandit
        ///faucibus. Integer eros felis, gravida in, imperdiet a,
        ///blandit non, sapien. Vivamus vulputate dui bibendum
        ///nisl. Curabitur est ligula, eleifend eget, porta eu,
        ///convallis at, orci.</remarks>
        protected static void StaticMethodB() {}

        ///<summary>Aliquam erat volutpat. Sed rhoncus. Maecenas massa
        ///nunc, facilisis sed, rutrum vel, tincidunt a, lectus. Donec.
        ///</summary><remarks>ipsum. Lorem ipsum dolor sit amet, consectetuer adipiscing
        ///elit. Sed placerat eros ac dui. In hac habitasse platea
        ///dictumst. Phasellus mauris purus, congue a, sagittis nec,
        ///faucibus at, nunc. Morbi bibendum magna nec
        ///nisi. Suspendisse libero. Etiam ut nisi. Nunc tempor, nulla
        ///id posuere feugiat, lacus libero consectetuer odio, ut
        ///laoreet quam ipsum at risus. Donec egestas. Maecenas
        ///interdum, libero eget blandit ultrices, nisl leo molestie
        ///quam, a rhoncus enim lacus ut enim. Vestibulum ligula erat,
        ///tincidunt eget, porta nec, volutpat vel, arcu.</remarks>
        private static void StaticMethodC() {
            new OneHello("h", "i");
        }


        ///<summary>Suspendisse ultrices commodo nunc. Nulla hendrerit
        ///enim ac ante. Cum sociis natoque penatibus et magnis dis.
        ///</summary><remarks>parturient montes, nascetur ridiculus mus. Curabitur in
        ///lectus sit amet odio accumsan ultricies. Pellentesque
        ///convallis tellus in neque. Nulla sed dolor. Sed a tortor
        ///nec augue venenatis condimentum. Duis interdum ligula vitae
        ///nunc. Etiam tincidunt sodales ligula. Ut ultricies
        ///mauris. Vestibulum pharetra lacus id massa. Sed convallis
        ///enim nec dolor. Nunc rhoncus est at leo. Pellentesque
        ///suscipit nisl vitae velit. Ut porttitor iaculis
        ///risus. Praesent leo. Quisque pellentesque consectetuer
        ///lectus. Integer sed nisi. Nulla tempus, odio sed
        ///condimentum consequat, odio metus viverra orci, sed
        ///facilisis orci odio in sem.</remarks>
        public int m_A = 123;

        ///<summary>Duis pellentesque imperdiet dui. Vestibulum in
        ///purus. Proin eu risus tempus leo aliquet ullamcorper. Cras.
        ///</summary><remarks>nulla. Ut eu dolor euismod erat laoreet aliquet. Maecenas
        ///pharetra condimentum dui. In hac habitasse platea
        ///dictumst. In venenatis accumsan massa. Duis nec
        ///risus. Mauris dolor felis, lacinia et, tincidunt in,
        ///feugiat nec, felis. Fusce at leo sed quam congue
        ///egestas. Donec velit tellus, fringilla eu, vestibulum sed,
        ///vulputate at, lorem. Curabitur arcu risus, molestie eu,
        ///pellentesque ut, sodales at, nisi. Ut tempor massa et
        ///enim. Ut aliquet.</remarks>
        protected string m_B = "hello";

        ///<summary>Ut a elit in orci lobortis bibendum. Donec
        ///pretium, eros id feugiat aliquet, nulla pede nonummy.
        ///</summary><remarks>tortor, vel mattis nunc lacus in purus. Ut nec quam non
        ///enim rutrum commodo. Proin erat orci, tempus semper,
        ///suscipit in, commodo et, ligula. Mauris sit amet
        ///erat. Pellentesque consequat, sapien eget condimentum
        ///feugiat, lorem lectus porta sem, eu eleifend ligula lacus
        ///ac nulla. Quisque mattis, ipsum ut vehicula placerat, dolor
        ///neque feugiat sapien, a tempor metus sapien vitae
        ///odio. Nulla tincidunt. Vestibulum ante ipsum primis in
        ///faucibus orci luctus et ultrices posuere cubilia Curae;
        ///Donec iaculis mattis justo. In hac habitasse platea
        ///dictumst. Sed nunc orci, scelerisque a, euismod
        ///sollicitudin, viverra a, dolor. Nunc nunc arcu, vehicula
        ///eget, consectetuer vulputate, consequat at, nisi. Phasellus
        ///at odio. In mi tortor, aliquet eget, ultrices ac, iaculis
        ///at, neque. Etiam ornare ultricies purus. Nullam vestibulum
        ///cursus tellus. In vitae lectus vitae eros malesuada
        ///tempor. Proin vitae turpis a tortor lobortis
        ///eleifend.</remarks>
        private double m_C = 456.789;


        ///<summary>Sed varius, risus et laoreet nonummy, libero dolor
        ///aliquam ligula, consequat rutrum sapien urna at nibh. Nulla.
        ///</summary><remarks>nunc arcu, laoreet ac, dignissim eu, eleifend sed,
        ///pede. Nulla purus. Sed et risus. Sed ac diam sed neque
        ///ultrices imperdiet. Aliquam leo. Praesent suscipit mollis
        ///augue. Suspendisse faucibus dignissim justo. Nam rutrum
        ///turpis. Class aptent taciti sociosqu ad litora torquent per
        ///conubia nostra, per inceptos hymenaeos. Nulla vel
        ///turpis. Donec ullamcorper risus a libero. Donec arcu felis,
        ///feugiat in, pellentesque non, convallis venenatis,
        ///justo. Integer quis justo. Quisque condimentum pellentesque
        ///nisl. Ut ac lorem id purus consectetuer commodo.</remarks>
        public int A { get { return m_A; } }

        ///<summary>Cras tempus, mi quis facilisis fringilla, odio
        ///justo vehicula lorem, et aliquam massa nunc nec nisi. Cras.
        ///</summary><remarks>dapibus velit vitae tortor. Mauris pharetra lacus sit amet
        ///dolor. In erat. Aliquam posuere odio eget nisl. Fusce non
        ///augue. Aenean pharetra ipsum et enim. Sed at enim. Maecenas
        ///metus quam, varius sed, ultrices in, hendrerit ut,
        ///eros. Fusce turpis. Nullam facilisis. Praesent massa purus,
        ///consequat sit amet, rutrum posuere, adipiscing eget,
        ///magna. Pellentesque habitant morbi tristique senectus et
        ///netus et malesuada fames ac turpis egestas. Nullam
        ///sagittis. Cras eget nunc a orci ornare laoreet. Ut tellus
        ///dui, vulputate ut, dictum mattis, ultrices vel, risus. Ut
        ///nunc nulla, elementum sit amet, feugiat sit amet, sagittis
        ///a, nunc. Aenean mattis venenatis dui. Aenean est.</remarks>
        protected string B { get { return m_B; } set { m_B = value; }  }

        ///<summary>Pellentesque tempor consequat eros. Suspendisse
        ///aliquet ante eu mi. Duis vitae massa. Pellentesque vitae.
        ///</summary><remarks>urna vitae leo consequat vestibulum. Maecenas vitae erat
        ///sed mauris scelerisque facilisis. Sed eu dui. Aliquam
        ///aliquet diam ut turpis. Fusce ultricies dictum
        ///velit. Pellentesque vel libero sed mauris semper
        ///lacinia. Mauris accumsan, quam at ultrices mollis, nisi
        ///turpis sollicitudin purus, ac fermentum mauris quam eu
        ///libero. Duis suscipit magna eget enim. Nullam urna risus,
        ///interdum eget, viverra vitae, malesuada vitae,
        ///elit. Maecenas in sapien eu velit ornare mollis. Aenean
        ///nibh risus, viverra at, malesuada sit amet, pharetra quis,
        ///metus. Pellentesque feugiat, justo convallis adipiscing
        ///dictum, nisi eros sodales nisi, sit amet vulputate nunc
        ///tellus nec leo. Class aptent taciti sociosqu ad litora
        ///torquent per conubia nostra, per inceptos hymenaeos. Morbi
        ///tortor arcu, convallis id, facilisis eu, ultrices et,
        ///nisi. Praesent ut nulla vitae massa consequat semper. Morbi
        ///fringilla orci nec mauris. Nullam sed orci eget nunc luctus
        ///molestie.</remarks>
        private double C { get { return m_C; } set { m_C = value; } }


        ///<summary>Suspendisse potenti. Etiam consectetuer ante eu
        ///dui. Etiam semper. Aliquam vel nulla vel lorem lacinia.
        ///</summary><remarks>congue. Class aptent taciti sociosqu ad litora torquent per
        ///conubia nostra, per inceptos hymenaeos. Sed ante diam,
        ///laoreet at, vehicula ut, auctor vitae, justo. Lorem ipsum
        ///dolor sit amet, consectetuer adipiscing elit. Vestibulum
        ///cursus, erat quis mollis luctus, est leo semper felis,
        ///vitae egestas arcu tellus consequat metus. Aenean bibendum
        ///sem non neque. Quisque libero lacus, imperdiet eu,
        ///ullamcorper scelerisque, euismod feugiat, magna. In
        ///ultricies, turpis at facilisis imperdiet, augue ligula
        ///bibendum risus, id tincidunt nisi turpis eget
        ///elit. Maecenas dictum neque at mi. Nam quis nibh. Nullam
        ///ligula turpis, pharetra vel, ornare at, cursus eget,
        ///enim.</remarks>
        public OneHello() {}

        ///<summary>In iaculis condimentum pede. Pellentesque vitae
        ///nulla. Aenean ullamcorper. Curabitur sed elit eu nulla.
        ///</summary><remarks>luctus adipiscing. Sed eget quam vitae augue lacinia
        ///molestie. Donec dignissim auctor lorem. Ut ac
        ///nibh. Pellentesque habitant morbi tristique senectus et
        ///netus et malesuada fames ac turpis egestas. Aliquam
        ///faucibus nonummy dolor. Sed feugiat dapibus diam. Vivamus
        ///eget lectus. Proin pharetra lacus sit amet nisi. Curabitur
        ///ullamcorper fermentum turpis. Donec nisl velit, luctus nec,
        ///pharetra a, pretium et, mi.</remarks>
        public OneHello(int a) {}

        ///<summary>Proin nibh. Donec dui odio, malesuada ac,
        ///tristique ut, tempus eu, elit. Duis egestas risus sed.
        ///</summary><remarks>metus. Aliquam ullamcorper. In hac habitasse platea
        ///dictumst. Mauris vel ante. Curabitur diam elit, ornare sed,
        ///commodo in, ornare rutrum, ante. Nunc nibh arcu, pretium
        ///et, aliquam eget, laoreet eu, odio. Curabitur volutpat, leo
        ///ut auctor facilisis, mauris justo consequat ante, eu
        ///adipiscing metus diam at libero. Fusce accumsan sapien nec
        ///purus. Vivamus sagittis. Cras massa orci, euismod id,
        ///blandit eu, blandit eget, tellus. Phasellus risus. Maecenas
        ///nonummy aliquam orci. Curabitur fermentum pede et mi. Ut
        ///aliquet. Nulla quis erat vitae odio blandit
        ///faucibus. Integer eros felis, gravida in, imperdiet a,
        ///blandit non, sapien. Vivamus vulputate dui bibendum
        ///nisl. Curabitur est ligula, eleifend eget, porta eu,
        ///convallis at, orci.</remarks>
        public OneHello(int a, string b, double c) {}


        ///<summary>Aliquam erat volutpat. Sed rhoncus. Maecenas massa
        ///nunc, facilisis sed, rutrum vel, tincidunt a, lectus. Donec.
        ///</summary><remarks>ipsum. Lorem ipsum dolor sit amet, consectetuer adipiscing
        ///elit. Sed placerat eros ac dui. In hac habitasse platea
        ///dictumst. Phasellus mauris purus, congue a, sagittis nec,
        ///faucibus at, nunc. Morbi bibendum magna nec
        ///nisi. Suspendisse libero. Etiam ut nisi. Nunc tempor, nulla
        ///id posuere feugiat, lacus libero consectetuer odio, ut
        ///laoreet quam ipsum at risus. Donec egestas. Maecenas
        ///interdum, libero eget blandit ultrices, nisl leo molestie
        ///quam, a rhoncus enim lacus ut enim. Vestibulum ligula erat,
        ///tincidunt eget, porta nec, volutpat vel, arcu.</remarks>
        protected OneHello(string x) {}

        ///<summary>Suspendisse ultrices commodo nunc. Nulla hendrerit
        ///enim ac ante. Cum sociis natoque penatibus et magnis dis.
        ///</summary><remarks>parturient montes, nascetur ridiculus mus. Curabitur in
        ///lectus sit amet odio accumsan ultricies. Pellentesque
        ///convallis tellus in neque. Nulla sed dolor. Sed a tortor
        ///nec augue venenatis condimentum. Duis interdum ligula vitae
        ///nunc. Etiam tincidunt sodales ligula. Ut ultricies
        ///mauris. Vestibulum pharetra lacus id massa. Sed convallis
        ///enim nec dolor. Nunc rhoncus est at leo. Pellentesque
        ///suscipit nisl vitae velit. Ut porttitor iaculis
        ///risus. Praesent leo. Quisque pellentesque consectetuer
        ///lectus. Integer sed nisi. Nulla tempus, odio sed
        ///condimentum consequat, odio metus viverra orci, sed
        ///facilisis orci odio in sem.</remarks>
        private OneHello(string x, string y) {
            m_C = s_m_C = CC;
            C = SC = CC;
        }

        ///<summary>Performs some task.</summary>
        ///<remarks>
        ///<para>
        ///Performs some <code>code</code>-oriented task.
        ///</para>
        ///<example>
        ///<code>
        ///  ...;
        ///  A(new Fuller(Example()));
        ///  SomeMethod();
        ///  Cleanup();
        ///  ...;
        ///</code>
        ///</example>
        ///</remarks>
        public string SomeMethod() {
            return null;
        }

        ///<summary>Gets an instance of OutsideAllNamespaces.</summary>
        public OutsideAllNamespaces GetOutsideAllNamespaces() { return null; }
    }
}

namespace net.lshift.ndocproc.examples.two {
    ///<summary>A delegate.</summary>
    public delegate int BinaryIntFunction(int one, int two);

    ///<summary>An event handler.</summary>
    public delegate void SomeEventHandler(object sender, System.EventArgs args);

    ///<summary>Donec laoreet arcu lobortis sem. Mauris
    ///elementum. Aenean feugiat magna vitae urna. Cras
    ///posuere. Vestibulum nec risus. Duis et erat. In
    ///purus. Aliquam sed est. Maecenas molestie lacus id
    ///arcu. Duis nibh. Praesent arcu est.</summary>
    ///
    ///<remarks>
    ///
    ///<para>Lorem ipsum dolor sit amet, consectetuer adipiscing
    ///elit. Ut interdum aliquet quam. Donec metus turpis, luctus ut,
    ///eleifend ut, porttitor ut, arcu. Maecenas nisl massa, vulputate
    ///ac, euismod vitae, dapibus vitae, dolor. Praesent ipsum. Donec
    ///vitae pede vitae neque suscipit auctor. Pellentesque odio est,
    ///sagittis sit amet, mollis in, sollicitudin quis,
    ///lacus. Pellentesque tortor sem, adipiscing eu, faucibus vel,
    ///elementum sed, justo. Nullam consequat diam nec purus. Praesent
    ///nec justo. In vitae mi. Phasellus eget arcu. Nulla ac velit ut
    ///tortor iaculis pulvinar. Etiam vitae sem. Duis fringilla
    ///faucibus quam. Nam magna massa, sodales imperdiet, rutrum vel,
    ///hendrerit malesuada, nibh. Vivamus euismod. Phasellus nisl leo,
    ///auctor a, placerat et, vehicula quis, tellus. Quisque vel
    ///sapien. Ut imperdiet.</para>
    ///
    ///<para>Donec sed metus. Integer euismod, odio eu consectetuer
    ///lacinia, arcu mi pulvinar sapien, at vehicula neque nunc quis
    ///lorem. Suspendisse varius tempus dui. Suspendisse porta neque
    ///eget pede accumsan cursus. Nam nec eros. Nunc sem turpis,
    ///tincidunt id, adipiscing at, blandit eu, pede. Sed dolor. Donec
    ///eget augue. Integer placerat blandit diam. Ut non lorem quis
    ///lectus dictum semper. Cras vitae turpis at leo lacinia
    ///porttitor. Phasellus sed dolor. Nullam ligula dui, congue ut,
    ///fringilla elementum, pretium ac, metus. Nam sem. Fusce tempor
    ///accumsan nunc. Proin metus turpis, luctus vitae, lobortis at,
    ///porttitor eu, urna. Sed sit amet felis eget tellus pellentesque
    ///euismod. In hac habitasse platea dictumst. Etiam luctus.</para>
    ///
    ///<para>Maecenas pretium neque convallis mi. Nulla massa. Nullam
    ///in mi. Sed interdum. Integer quis erat in velit eleifend
    ///volutpat. Praesent dolor metus, pulvinar ut, pharetra ac,
    ///molestie nec, diam. In cursus interdum velit. Pellentesque
    ///lacus nulla, faucibus non, ullamcorper et, sollicitudin a,
    ///turpis. Donec id diam ac nisl adipiscing laoreet. Maecenas eget
    ///justo a quam tincidunt suscipit. Etiam interdum consectetuer
    ///enim. Praesent imperdiet. Duis imperdiet lectus non
    ///massa. Mauris laoreet nisi ac ante. Pellentesque tristique
    ///lectus quis neque. Nulla egestas consequat urna.</para>
    ///
    ///</remarks>
    public interface TwoHello {
        ///<summary>An event.</summary>
        event SomeEventHandler SomeEvent;

        ///<summary>Read-only</summary>
        int MyPropertyRO { get; }
        ///<summary>Read-write</summary>
        int MyPropertyRW { get; set; }

        ///<summary>Donec laoreet arcu lobortis sem. Mauris
        ///elementum. Aenean feugiat magna vitae urna. Cras
        ///posuere. Vestibulum nec risus. Duis et erat. In
        ///purus. Aliquam sed est. Maecenas molestie lacus id
        ///arcu. Duis nibh. Praesent arcu est.</summary>
        ///<see cref="ProtocolViolationException"/>
        net.lshift.ndocproc.examples.one.OneHello GetHello();

	///<summary>Retrieve a cuboid of OneHello instances</summary>
	net.lshift.ndocproc.examples.one.OneHello[][][] GetHellos();

	///<summary>Get the bytes</summary>
	byte[] GetBytes();

	///<summary>Exhibit arrays</summary>
	int[][] GetIntMatrix();

        ///<summary>ArrayParameter1 doc</summary>
        void ArrayParameter1(object[] arg);

        ///<summary>ArrayParameter2 doc</summary>
        void ArrayParameter2(object[][] arg);

        ///<summary>OutParameter1 doc</summary>
        void OutParameter1(out object arg);

        ///<summary>OutParameter2 doc</summary>
        void OutParameter2(out object[] arg);

        ///<summary>RefParameter1 doc</summary>
        void RefParameter1(ref object arg);

        ///<summary>RefParameter2 doc</summary>
        void RefParameter2(ref object[] arg);
    }

    ///<summary>The outer class</summary>
    public class Outerclass {
        ///<summary>The inner class</summary>
        public class Innerclass<TProperty> {
            ///<summary>A generic unary function delegate.</summary>
            public delegate TResult UnaryFunction<TResult, TArgument>(TArgument arg);

            ///<summary>Retrieve a property</summary>
            public TProperty Property { get { return default(TProperty); } }

            ///<summary>Default ctor</summary>
            public Innerclass() {}

            ///<summary>An inner, inner class</summary>
            public class DoubleInner<TResult> {
                ///<summary>Default ctor</summary>
                public DoubleInner() {}

                ///<summary>A method demonstrating more baroque syntax</summary>
                public void Zot<TArg>(UnaryFunction<TResult, TArg> f) {}
            }

            ///<summary>Yet more baroque syntax</summary>
            public void Bar<R>(UnaryFunction<R, int> f) {}
        }

        ///<summary>A nongeneric inner class</summary>
        public class Nongen {
            ///<summary>Default ctor</summary>
            public Nongen() {}
        }

        ///<summary>Inner delegate type definition</summary>
        public delegate void Innerdelegate(string arg);

        ///<summary>Delegate field declaration</summary>
        public Innerdelegate m_d;

        ///<summary>An array of a generic type</summary>
        public Innerclass<int>[] someInstances;

        ///<summary>An event</summary>
        public event Innerdelegate an_event;

        ///<summary>Ctor</summary>
        public Outerclass(Innerdelegate d, Nongen n, Innerclass<int> v) {}

        ///<summary>A method demonstrating syntax for nested generic types</summary>
        public void Foo<R>(Innerclass<string>.UnaryFunction<R, int> f) {}

        ///<summary>A method demonstrating more syntax for nested generic types</summary>
        public void Quux<TProperty, R>(Innerclass<TProperty>.UnaryFunction<R, int> f) {}

        ///<summary>Retrieves a UnaryFunction for AddOne</summary>
        public Innerclass<T>.UnaryFunction<int, int> GetAddOneFn<T>() {
            return new Innerclass<T>.UnaryFunction<int, int>(AddOne);
        }

        ///<summary>Adds one to its argument</summary>
        public int AddOne(int x) {
            return x + 1;
        }

        ///<summary>Retrieve V</summary>
        public Innerclass<int> V { get { return null; } }

        ///<summary>Retrieve D</summary>
        public Innerdelegate D { get { return m_d; } }
    }
}
