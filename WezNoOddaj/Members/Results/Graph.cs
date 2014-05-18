using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using WezNoOddajLib.Members;

namespace WezNoOddaj.Members.Results
{
    public class Graph
    {
        #region Members

        private List<IMemberInfo> _memebers;

        private List<Node> _nodes;
        private List<Edge> _edges;

        private float _avarage;

        /// <summary>
        /// Docelowa kwota, którą każdy użytkownik musi wnieść.
        /// </summary>
        public float Average
        {
            get
            {
                if (_avarage == float.MinValue)
                    _avarage = _memebers.Average(i => i.Share);

                return _avarage;
            }
        }

        #endregion

        public Graph(List<IMemberInfo> members)
        {
            _memebers = members;
            _nodes = new List<Node>();
            _edges = new List<Edge>();
        }

        private void GenerateGraph(IMemberInfo member)
        {
            List<IMemberInfo> sponsors = _memebers.Where(m => m.Share > Average).ToList();
            List<IMemberInfo> dabters = _memebers.Where(m => m.Share < Average).ToList();

            foreach (IMemberInfo sponsor in sponsors)
            {
                _nodes.Add(
                    CreateMemberNode(sponsor, dabters)
                );
            }
        }

        /// <summary>
        /// Utworzenie węzła głównego.
        /// </summary>
        /// <param name="member"></param>
        /// <param name="theOthers"></param>
        /// <returns></returns>
        private Node CreateMemberNode(IMemberInfo member, List<IMemberInfo> theOthers)
        {
            Node node = new Node(member);

            while (node.CurrentValue != Average)
            {
                IMemberInfo memeber = theOthers.FirstOrDefault();
                if (member != null)
                {
                    Node newNode = _nodes.Where(n => n.AlreadyExist(member)).SingleOrDefault();
                    if(newNode == null)
                        newNode = new Node(member);

                    float debt = node.CurrentValue - Average > Average - newNode.CurrentValue ? Average - newNode.CurrentValue : node.CurrentValue - Average;

                    _edges.Add(
                        newNode.Connect(node, debt)
                    );

                    _nodes.Add(newNode);

                    // Jeżeli użytkownik został spłacony to jest usuwany z listy dłużników.

                    if (newNode.CurrentValue == Average)
                        theOthers.Remove(member);
                }
                else
                {
                    // Sytuacja nie powinna nigdy wystąpić.
                    break;
                }
            }

            return node;
        }
    }
}
