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
        Dictionary<TreeNode, ShapeViewer> ShapeDictionary = new Dictionary<TreeNode, ShapeViewer>();
        public TreeViewer(TreeView viewer, ListShape<ShapeViewer> shapeViewers)
        {
            _viewer = viewer;
            formingTree(shapeViewers);
        }

        public void Update(ISubject subject, ShapeViewer enabledShape)
        {
            if(subject is ListShape<ShapeViewer>)
            {
                formingTree(subject as ListShape<ShapeViewer>);
            }
        }

        void formingTree(ListShape<ShapeViewer> shapeViewers)
        {
            _viewer.Nodes.Clear();
            TreeNode treeNode = new TreeNode(shapeViewers.ToString());
            _viewer.Nodes.Add(treeNode);
            if (shapeViewers is MyListShape)
            {
                foreach(var shape in shapeViewers as MyListShape)
                {
                    processNode(treeNode, shape);
                }
            }
        }

        void processNode(TreeNode node, ShapeViewer shape)
        {
            TreeNode treeNode = new TreeNode(shape.ToString());
            node.Nodes.Add(treeNode);
            ShapeDictionary.Add(treeNode, shape);
            if (shape.enabled)
            {
                treeNode.BackColor = Color.MediumSlateBlue;
                treeNode.ForeColor = Color.White;
            }
            if (shape is Group)
            {
                foreach(var shap in shape as Group)
                {
                    processNode(treeNode, shap);
                }
            }
            _viewer.ExpandAll();
        }
        public void enabled(TreeNode treeNode)
        {
            foreach(var shape in ShapeDictionary)
            {
                shape.Value.enabled = false;
                shape.Key.BackColor = Color.White;
                shape.Key.ForeColor = Color.Black;
            }
            ShapeDictionary[treeNode].enabled = true;
        }
    }
}
