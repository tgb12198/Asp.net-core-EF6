using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model
{
    public class SelectModel
    {
        /// <summary>
        /// 选项值
        /// </summary>
        public int value { get; set; }

        /// <summary>
        /// 选项标题
        /// </summary>
        public string label { get; set; }

        /// <summary>
        /// 是否禁用
        /// </summary>
        public bool disabled { get; set; }
    }
}
