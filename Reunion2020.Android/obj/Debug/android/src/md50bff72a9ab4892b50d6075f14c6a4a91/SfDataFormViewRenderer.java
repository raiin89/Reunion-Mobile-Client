package md50bff72a9ab4892b50d6075f14c6a4a91;


public class SfDataFormViewRenderer
	extends md51558244f76c53b6aeda52c8a337f2c37.ViewRenderer_2
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onLayout:(ZIIII)V:GetOnLayout_ZIIIIHandler\n" +
			"";
		mono.android.Runtime.register ("Syncfusion.XForms.Android.DataForm.SfDataFormViewRenderer, Syncfusion.SfDataForm.XForms.Android", SfDataFormViewRenderer.class, __md_methods);
	}


	public SfDataFormViewRenderer (android.content.Context p0, android.util.AttributeSet p1, int p2)
	{
		super (p0, p1, p2);
		if (getClass () == SfDataFormViewRenderer.class)
			mono.android.TypeManager.Activate ("Syncfusion.XForms.Android.DataForm.SfDataFormViewRenderer, Syncfusion.SfDataForm.XForms.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public SfDataFormViewRenderer (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == SfDataFormViewRenderer.class)
			mono.android.TypeManager.Activate ("Syncfusion.XForms.Android.DataForm.SfDataFormViewRenderer, Syncfusion.SfDataForm.XForms.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new java.lang.Object[] { p0, p1 });
	}


	public SfDataFormViewRenderer (android.content.Context p0)
	{
		super (p0);
		if (getClass () == SfDataFormViewRenderer.class)
			mono.android.TypeManager.Activate ("Syncfusion.XForms.Android.DataForm.SfDataFormViewRenderer, Syncfusion.SfDataForm.XForms.Android", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
	}


	public void onLayout (boolean p0, int p1, int p2, int p3, int p4)
	{
		n_onLayout (p0, p1, p2, p3, p4);
	}

	private native void n_onLayout (boolean p0, int p1, int p2, int p3, int p4);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
