using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CptS321
{
    /// <summary>
    /// This is the Spreadsheet class that will set up the cell 
    /// </summary>
    public class Spreadsheet
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Spreadsheet"/> class.
        /// </summary>
        /// <param name="numRows">Set number of rows in spreadsheet.</param>
        /// <param name="numColumns">Set number of columns in spreadsheet.</param>
        public Spreadsheet(int numRows, int numColumns)
        {
            SpreadsheetCellValue[,] cellGrid = new SpreadsheetCellValue[numRows, numColumns];

            for (int i = 0; i < numRows; i++)
            {
                for (int j = 0; j < numColumns; j++)
                {
                    cellGrid[i,j].PropertyChanged += this.SpreadsheetCellValue_PropertyChanged;
                }
            }
        }

        private void SpreadsheetCellValue_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        public void test()
        {

        }
    }
}
