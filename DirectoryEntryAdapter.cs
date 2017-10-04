using System;
using System.Collections.Generic;
using Android.Support.V7.Widget;
using Android.Widget;
using Android.Views;

namespace FS_AddVolAndroid
{
	/// <summary>
	/// Provide views to RecyclerView with the directory entries.
	/// </summary>
	public class DirectoryEntryAdapter : RecyclerView.Adapter
	{
        protected static readonly string DIRECTORY_MIME_TYPE = "vnd.android.document/directory";
		List<DirectoryEntry> mDirectoryEntries;

        public DirectoryEntryAdapter (List<DirectoryEntry> directoryEntries)
		{
			mDirectoryEntries = directoryEntries;
		}

		public override RecyclerView.ViewHolder OnCreateViewHolder (ViewGroup parent, int viewType)
		{
			View v = LayoutInflater.From (parent.Context)
				.Inflate (Resource.Layout.directory_item, parent, false);
			return new DirectoryEntryAdapter.ViewHolder (v);
		}

		public override void OnBindViewHolder (RecyclerView.ViewHolder holder, int position)
		{
			var myHolder = (ViewHolder)holder;
			myHolder.mFileName.Text = mDirectoryEntries [position].fileName;
			//myHolder.mImageView.setText(mDirectoryEntries[position].mimeType);

			if (DIRECTORY_MIME_TYPE == (mDirectoryEntries [position].mimeType)) {
				myHolder.mImageView.SetImageResource (Resource.Drawable.ic_folder_grey600_36dp);
			} else {
				myHolder.mImageView.SetImageResource (Resource.Drawable.ic_description_grey600_36dp);
			}
		}



        public override int ItemCount {
			get {
				return mDirectoryEntries.Count;
			}
		}

		public void SetDirectoryEntries (List<DirectoryEntry> directoryEntries)
		{
			mDirectoryEntries = directoryEntries;
		}

		public class ViewHolder : RecyclerView.ViewHolder
		{
			public readonly TextView mFileName;
			public readonly TextView mMimeType;
			public readonly ImageView mImageView;

			public ViewHolder (View v) : base (v)
			{
				mFileName = (TextView)v.FindViewById (Resource.Id.textview_filename);
				mMimeType = (TextView)v.FindViewById (Resource.Id.textview_mimetype);
				mImageView = (ImageView)v.FindViewById (Resource.Id.entry_image);
			}
		}
	}
}

