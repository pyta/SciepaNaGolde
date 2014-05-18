using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WezNoOddaj.Members.Results
{
    public class Edge
    {
        #region Members

        private float _debt;

        /// <summary>
        /// Kwota do oddania.
        /// </summary>
        public float Debt 
        {
            get { return _debt; }  
        }

        /// <summary>
        /// Węzeł oddający.
        /// </summary>
        private Node _startNode;

        /// <summary>
        /// Wezeł, któremu się oddaje.
        /// </summary>
        private Node _endNode;

        #endregion

        public Edge(float debt, Node startNode, Node endNode)
        {
            _debt = debt;
            _startNode = startNode;
            _endNode = endNode;
        }
    }
}
