using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;
using System.IO;

namespace OOP_4
{
    class TreeViewer : IObserver
    {
        TreeView _viewer;

        public TreeViewer(TreeView viewer)
        {
            _viewer = viewer;
        }

        public void Update(ISubject shapes)
        {
            _viewer.Nodes.Clear();
            TreeNode treeNode = new TreeNode(shapes.ToString());
            _viewer.Nodes.Add(treeNode);
            if (shapes is MyListShape)
            {
                foreach(var shape in shapes as MyListShape)
                {
                    processNode(treeNode, shape);
                }
            }
        }
        void processNode(TreeNode node, ShapeViewer shape)
        {
            TreeNode treeNode = new TreeNode(shape.ToString());
            //node.Nodes.Add(treeNode);
            node.Nodes.Add(treeNode);
            if (shape is Group)
            {
                foreach(var shap in shape as Group)
                {
                    processNode(treeNode, shap);
                }
            }
            _viewer.ExpandAll();

        }


        private class Node
        {
            List<Node> nodes;
            public void Add(Node node)
            {
                nodes.Add(node);
            }
        }

    }
}
