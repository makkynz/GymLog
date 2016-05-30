package md5fe439492bfa6be88e6b31b9b10d06a23;


public class AddExercise
	extends android.app.Activity
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("GymLog.Activities.AddExercise, GymLog, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", AddExercise.class, __md_methods);
	}


	public AddExercise () throws java.lang.Throwable
	{
		super ();
		if (getClass () == AddExercise.class)
			mono.android.TypeManager.Activate ("GymLog.Activities.AddExercise, GymLog, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);

	java.util.ArrayList refList;
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
