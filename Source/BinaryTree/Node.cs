
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace BinaryTree
{
    
    /// an object representing a node. a node is a part of the binary tree which contains data
  
    public class Node
    {
        
       
        
        public int Value { get; set; }
       
        /// gets or sets the right node connected to this node, if any
        
        public Node Right { get; set; }
        /// <summary>
        /// gets or sets the left node connected to this node, if any
        /// </summary>
        public Node Left { get; set; }

        
        /// true if the node does not have any child, otherwise false
        public bool IsSingle { get { return Right == null && Left == null; } }

        /// constructor 1. creates new instance of node
        public Node(int value)
            : this(value, null, null)
        {
        }
        public Node(int value, Node left, Node right)
        {
            Right = left;
            Left = right;
            Value = value;
        }

        
        private static Bitmap _nodeBg = new Bitmap(30, 25);
        
        private static Size _freeSpace = new Size(_nodeBg.Width / 8, (int)(_nodeBg.Height * 1.3f));
        
        private static readonly float Coef = _nodeBg.Width / 40f;

        
        static Node()
        {
            var g = Graphics.FromImage(_nodeBg);                                    // get a Graphics from _nodeBg bitmap, 
            g.SmoothingMode = SmoothingMode.HighQuality;                            // set the smoothing mode
            var rcl = new Rectangle(1, 1, _nodeBg.Width - 2, _nodeBg.Height - 2);   // get a rectangle of drawer
            g.FillRectangle(Brushes.White, rcl);
            g.DrawEllipse(new Pen(Color.Black, 1.2f), rcl);                          // draw ellipse, you could also comment this line, and uncomment the above line as another option for background image
        }

        
        public bool Add(Node node)
        {
            if (!node.IsSingle)// if the node is not single do not add it!, you can change the code in order to make it addable!
                throw new ArgumentException("the node should be single to be added.");

            var res = false;
            if (node.Value < Value) // add to left : it's value is less than the value of the current node
            {
                res = true;
                if (Left == null)
                    Left = node;
                else
                    res = Left.Add(node);
                IsChanged = true;
            }
            if (node.Value > Value) // add to right: it's value is greater than the value of the current node
            {
                res = true;
                IsChanged = true;
                if (Right == null)
                    Right = node;
                else
                    res = Right.Add(node);
            }
            return res;
        }

        
        public bool Remove(int nodeValue, out bool containedOnMe)
        {
            Node nodeToRemove;
            containedOnMe = false;
            // search for the node containing the nodeValue
            var isLeft = nodeValue < Value;
            if (nodeValue < Value)
                nodeToRemove = Left;
            else if (nodeValue > Value)
                nodeToRemove = Right;
            else
            {
                if (Left != null)
                    Left.IsChanged = true;
                if (Right != null)
                    Right.IsChanged = true;
                // the current node contains the nodeValue.
                // search is completed
                containedOnMe = true;
                return false; // not yet removed!
            }

            if (nodeToRemove == null)
                return false;

            bool containOnChild;
            var result = nodeToRemove.Remove(nodeValue, out containOnChild);
            if (containOnChild) // if the child of the current node contained the nodeValue, that child should be removed.
            {
                IsChanged = true;
                if (nodeToRemove.Left == null && nodeToRemove.Right == null)// 1. the removing node has no child
                {
                    if (isLeft) Left = null; else Right = null;
                }
                else if (nodeToRemove.Right == null)                        // 2. the removing node has left child
                {
                    if (isLeft) Left = nodeToRemove.Left; else Right = nodeToRemove.Left;
                }
                else                                                        // left and right are not null
                {
                    if (nodeToRemove.Right.Left == null)                    // 3. the removing nodes' right child has no left child
                    {
                        nodeToRemove.Right.Left = nodeToRemove.Left;
                        if (isLeft)
                            Left = nodeToRemove.Right;
                        else
                            Right = nodeToRemove.Right;
                    }
                    else                                                    // 4. the removing nodes' right child has left child
                    {
                        Node theMostLeftChild = null;
                        for (var node = nodeToRemove.Right; node != null; node = node.Left)
                            if (node.Left == null)
                                theMostLeftChild = node;
                        bool temp;
                        var v = theMostLeftChild.Value;

                        // recursive call: removing the most left child of the right child of the removing node.
                        Remove(theMostLeftChild.Value, out temp);
                        nodeToRemove.Value = v;
                    }
                }
                return true;
            }
            return result;
        }

        private bool _isChanded = true;
       
        public bool IsChanged
        {
            get
            {
                if (_isChanded)
                    return true;
                var childsChanged = false;
                if (Left != null)
                    childsChanged |= Left.IsChanged;
                if (Right != null)
                    childsChanged |= Right.IsChanged;
                return childsChanged;
            }
            private set { _isChanded = value; }
        }
       
        Image _lastImage;
       
        /// the location of the node on the top of the _lastImage.
       
        private int _lastImageLocationOfStarterNode;
        private static Font font = new Font("Tahoma", 14f * Coef);
        
        public Image Draw(out int center)
        {
            center = _lastImageLocationOfStarterNode;
            if (!IsChanged) // if the current node and it's childs are up to date, just return the last drawed image.
                return _lastImage;

            var lCenter = 0;
            var rCenter = 0;

            Image lNodeImg = null, rNodeImg = null;
            if (Left != null)       // draw left node's image
                lNodeImg = Left.Draw(out lCenter);
            if (Right != null)      // draw right node's image
                rNodeImg = Right.Draw(out rCenter);

            // draw current node and it's childs (left node image and right node image)
            var lSize = new Size();
            var rSize = new Size();
            var under = (lNodeImg != null) || (rNodeImg != null);// if true the current node has childs
            if (lNodeImg != null)
                lSize = lNodeImg.Size;
            if (rNodeImg != null)
                rSize = rNodeImg.Size;

            var maxHeight = lSize.Height;
            if (maxHeight < rSize.Height)
                maxHeight = rSize.Height;

            if (lSize.Width <= 0)
                lSize.Width = (_nodeBg.Width - _freeSpace.Width) / 2;
            if (rSize.Width <= 0)
                rSize.Width = (_nodeBg.Width - _freeSpace.Width) / 2;

            var resSize = new Size
                              {
                                  Width = lSize.Width + rSize.Width + _freeSpace.Width,
                                  Height = _nodeBg.Size.Height + (under ? maxHeight + _freeSpace.Height : 0)
                              };

            var result = new Bitmap(resSize.Width, resSize.Height);
            var g = Graphics.FromImage(result);
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.FillRectangle(Brushes.White, new Rectangle(new Point(0, 0), resSize));
            g.DrawImage(_nodeBg, lSize.Width - _nodeBg.Width / 2 + _freeSpace.Width / 2, 0);
            var str = Value.ToString();
            g.DrawString(str, font, Brushes.Black, lSize.Width - _nodeBg.Width / 2 + _freeSpace.Width / 2 + (2 + (str.Length == 1 ? 10 : str.Length == 2 ? 5 : 0)) * Coef, _nodeBg.Height / 2f - 12 * Coef);


            center = lSize.Width + _freeSpace.Width / 2;
            var pen = new Pen(Brushes.Black, 1.2f * Coef)
                          {
                              EndCap = LineCap.ArrowAnchor,
                              StartCap = LineCap.Round
                          };


            float x1 = center;
            float y1 = _nodeBg.Height;
            float y2 = _nodeBg.Height + _freeSpace.Height;
            float x2 = lCenter;
            var h = Math.Abs(y2 - y1);
            var w = Math.Abs(x2 - x1);
            if (lNodeImg != null)
            {
                g.DrawImage(lNodeImg, 0, _nodeBg.Size.Height + _freeSpace.Height);
                var points1 = new List<PointF>
                                  {
                                      new PointF(x1, y1),
                                      new PointF(x1 - w/6, y1 + h/3.5f),
                                      new PointF(x2 + w/6, y2 - h/3.5f),
                                      new PointF(x2, y2),
                                  };
                g.DrawCurve(pen, points1.ToArray(), 0.5f);
            }
            if (rNodeImg != null)
            {
                g.DrawImage(rNodeImg, lSize.Width + _freeSpace.Width, _nodeBg.Size.Height + _freeSpace.Height);
                x2 = rCenter + lSize.Width + _freeSpace.Width;
                w = Math.Abs(x2 - x1);
                var points = new List<PointF>
                                 {
                                     new PointF(x1, y1),
                                     new PointF(x1 + w/6, y1 + h/3.5f),
                                     new PointF(x2 - w/6, y2 - h/3.5f),
                                     new PointF(x2, y2)
                                 };
                g.DrawCurve(pen, points.ToArray(), 0.5f);
            }
            IsChanged = false;
            _lastImage = result;
            _lastImageLocationOfStarterNode = center;
            return result;
        }

        /// <summary>
        /// returns true if the current node or it's childs containd the inserted value
        /// </summary>
        public bool Exists(int value)
        {
            var res = value == Value;
            if (!res && Left != null)
                res = Left.Exists(value);
            if (!res && Right != null)
                res = Right.Exists(value);
            return res;
        }
        /// <summary>
        /// the count of nodes under this node + 1
        /// </summary>
        public int Count
        {
            get
            {
                return 1 + (Left != null ? Left.Count : 0) + (Right != null ? Right.Count : 0);
            }
        }
    }
}