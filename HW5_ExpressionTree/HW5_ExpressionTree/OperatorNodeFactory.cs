using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CptS321
{
    /// <summary>
    /// This class will return the corresonding operator Node based on the string inputted.
    /// </summary>
    public class OperatorNodeFactory
    {
        /// <summary>
        /// Will return the corresponding operator node based on the string input.
        /// </summary>
        /// <param name="op">String operator.</param>
        /// <returns>Operator Node.</returns>
        public OperatorNode CreateOperatorNode(string op)
        {
            if (op == "+")
            {
                return new PlusOperatorNode();
            }
            else if (op == "-")
            {
                return new MinusOperatorNode();
            }
            else if (op == "*")
            {
                return new MultiplyOperatorNode();
            }
            else
            {
                return new DivideOperatorNode();
            }
        }
    }
}
