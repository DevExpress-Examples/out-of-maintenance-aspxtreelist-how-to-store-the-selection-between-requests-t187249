using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web.ASPxTreeList;
using System.Collections;

public partial class _Default : System.Web.UI.Page
{
	private const string selectedNodesKey = "selectedNodesKey";
	protected void Page_Load(object sender, EventArgs e) {
		treeList.DataBind();
	}


	protected void atlSelection_DataBinding(object sender, EventArgs e) {
		(sender as ASPxTreeList).DataSource = CreateLeftListDataSource();
	}
	private IEnumerable CreateLeftListDataSource() {
		for (int i = 0; i < 100; i++) {
			yield return new { ItemId = i, Code = "Code " + i, Name = "Name " + i, Description = "Description " + i, ItemType = i % 3, ParentId = i % 10, Price = i * 10.00, };
		}

	}

	protected void treeList_CustomCallback(object sender, TreeListCustomCallbackEventArgs e) {
		switch (e.Argument) {
			case "Save":
				SaveSelection();
				break;
			case "Restore":
				RestoreSelection();
				break;
		}
	}

	private void SaveSelection() {
		Session[selectedNodesKey] = treeList.GetSelectedNodes().Select(node => node.Key);

	}
	private void RestoreSelection() {
		if (Session[selectedNodesKey] == null)
			return;
		var rowKeys = (IEnumerable<string>)Session[selectedNodesKey];
		var iterator = treeList.CreateNodeIterator();
		iterator.Reset();

		while (iterator.Current != null) {
			iterator.Current.Selected = rowKeys.Contains(iterator.Current.Key);
			iterator.GetNext();
		}
	}
}