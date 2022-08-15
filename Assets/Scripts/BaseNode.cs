using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GalGameEditor
{
    [System.Serializable]
    public enum NODETYPE
    {
        START,
        DIALOGUE,
        CHOICE,
        EVENT,
    }

    [System.Serializable]
    public struct NodeData
    {
        public int Id;
        public NODETYPE nodeType;

        public NodeData(int Id, NODETYPE nodeType)
        {
            this.Id = Id;
            this.nodeType = nodeType;
        }
        
        public NodeData(NodeData data)
        {
            Id = data.Id;
            nodeType = data.nodeType;
        }
    }
    
    [System.Serializable]
    public abstract class BaseNode
    {
        protected NodeData m_NodeData;
        public NodeData NodeData { get { return m_NodeData; } set { m_NodeData = value; } }
        
        [SerializeField]
        protected List<NodeData> m_NextNodes;
        
        [SerializeField]
        protected List<NodeData> m_PreNodes;
        
        public BaseNode()
        {
            m_NextNodes = new List<NodeData>();
            m_PreNodes = new List<NodeData>();
        }
        
        public BaseNode(BaseNode node)
        {
            m_NodeData = new NodeData(node.m_NodeData);
            m_NextNodes = new List<NodeData>();
            m_PreNodes = new List<NodeData>();
            for (int i = 0; i < node.m_NextNodes.Count; i++)
            {
                m_NextNodes.Add(new NodeData(node.m_NextNodes[i]));
            }
            for (int i = 0; i < node.m_PreNodes.Count; i++)
            {
                m_PreNodes.Add(new NodeData(node.m_PreNodes[i]));
            }
        }
        
        public ref List<NodeData> GetNextNodes()
        {
            return ref m_NextNodes;
        }
        
        public ref List<NodeData> GetPreNodes()
        {
            return ref m_PreNodes;
        }
    }
}