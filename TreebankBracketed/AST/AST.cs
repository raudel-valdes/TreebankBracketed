using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace TreebankBracketed.AST
{
    class AST
    {
        protected string m_name = "un_defined";
        protected List<AST> m_children = new List<AST>();
        protected List<Operator> m_ops = new List<Operator>();
        protected AST m_parent = null;
        protected int m_id;

        public bool MakeGraphVizDotFile(string fileName, string title)
        {
            FileStream file;
            StreamWriter stream = null;

            try
            {
                file = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            }
            catch
            {
                return false;
            }
            stream = new StreamWriter(file);

            stream.WriteLine("digraph G {");
            stream.WriteLine("Title [label=\"" + title + "\",shape=box]");
            Dump(stream);
            stream.Write("}");

            if (stream != null)
            {
                stream.Close();
            }

            return true;
        }

        public virtual void Dump(StreamWriter sw)
        {
            sw.Write(UniqueName + "[label = \"" + Name);
            if (m_ops.Count > 0)
            {
                sw.Write(" |");
                foreach (AST.Operator i in m_ops)
                    sw.Write(i.ToString() + " ");
                sw.Write("|");
            }
            sw.Write("\"]\n");
            foreach (AST child in m_children)
            {
                sw.WriteLine(UniqueName + " -> " + child.UniqueName);
                child.Dump(sw);
            }
        }
    }
}
