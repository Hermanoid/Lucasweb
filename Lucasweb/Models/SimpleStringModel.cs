using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucasweb.Models
{
    public class SimpleStringModel
    {
        public SimpleStringModel()
        {

        }
        public SimpleStringModel(string Text)
        {
            this.Text = Text;
        }
        static public implicit operator string(SimpleStringModel ssm)
        {
            return ssm.Text;
        }
        static public implicit operator SimpleStringModel(string s)
        {
            return new SimpleStringModel(s);
        }
        public string Text { get; set; }
    }
}
