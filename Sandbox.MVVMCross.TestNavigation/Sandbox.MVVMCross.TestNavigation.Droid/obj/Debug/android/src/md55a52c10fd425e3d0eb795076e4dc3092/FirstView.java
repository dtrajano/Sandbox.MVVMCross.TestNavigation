package md55a52c10fd425e3d0eb795076e4dc3092;


public class FirstView
	extends md55a52c10fd425e3d0eb795076e4dc3092.BaseView
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("Sandbox.MVVMCross.TestNavigation.Droid.Views.FirstView, Sandbox_MVVMCross_TestNavigation.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", FirstView.class, __md_methods);
	}


	public FirstView ()
	{
		super ();
		if (getClass () == FirstView.class)
			mono.android.TypeManager.Activate ("Sandbox.MVVMCross.TestNavigation.Droid.Views.FirstView, Sandbox_MVVMCross_TestNavigation.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);

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