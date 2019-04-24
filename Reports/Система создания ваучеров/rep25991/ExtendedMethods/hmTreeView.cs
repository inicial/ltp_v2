using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace rep25991
{
    public static class hmTreeView
    {
        public static TreeNode[] GetCheckedNodes(this TreeView value)
        {
            return getChecked(value.Nodes).ToArray();
        }

        public static TreeNode FindNode(this TreeView value, string searchText)
        {
            return searchItem(value.Nodes, searchText);
        }

        private static List<TreeNode> getChecked(TreeNodeCollection value)
        {
            List<TreeNode> result = new List<TreeNode>();
            result.AddRange(value.OfType<TreeNode>().Where(x => x.Checked).ToArray());

            foreach (TreeNode itemNode in value.OfType<TreeNode>().Where(x => x.Nodes.Count > 0))
            {
                if (itemNode.Nodes.Count > 0)
                    result.AddRange(getChecked(itemNode.Nodes));
            }
            return result;
        }

        private static TreeNode searchItem(TreeNodeCollection value, string searchText)
        {
            var tempRes = value.OfType<TreeNode>().FirstOrDefault(x => x.Text.ToLower().Contains(searchText.ToLower()));
            if (tempRes != null)
                return tempRes;

            foreach (TreeNode itemNode in value.OfType<TreeNode>().Where(x => x.Nodes.Count > 0))
            {
                var q = searchItem(itemNode.Nodes, searchText.ToLower());
                if (q != null)
                    return q;
            }
            return null;
        }
    }
}
