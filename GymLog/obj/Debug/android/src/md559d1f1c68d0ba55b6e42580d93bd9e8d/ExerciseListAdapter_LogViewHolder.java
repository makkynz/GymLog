package md559d1f1c68d0ba55b6e42580d93bd9e8d;


public class ExerciseListAdapter_LogViewHolder
	extends android.support.v7.widget.RecyclerView.ViewHolder
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("GymLog.Adapters.ExerciseListAdapter+LogViewHolder, GymLog, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", ExerciseListAdapter_LogViewHolder.class, __md_methods);
	}


	public ExerciseListAdapter_LogViewHolder (android.view.View p0) throws java.lang.Throwable
	{
		super (p0);
		if (getClass () == ExerciseListAdapter_LogViewHolder.class)
			mono.android.TypeManager.Activate ("GymLog.Adapters.ExerciseListAdapter+LogViewHolder, GymLog, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.Views.View, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0 });
	}

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
