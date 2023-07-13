using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ML;
using Microsoft.ML.Internal.Utilities;
using Microsoft.ML.Runtime;

namespace VCELL_Emulator
{
    public class Differential
    {
        IDataView dataview;
        InputData InputData { get; set; }
        MLContext context;
        InputOutputColumnPair InputOutputColumnPair { get; set; }
        TransformsCatalog catalog;
        private DataViewRow row1;

        public DataViewRow Getrow()
        {
            return row1;
        }

        public void Setrow(DataViewRow value)
        {
            row1 = value;
        }

        DataColumn DataColumn { get; set; }

        private DataRowBuilder rowBuilder1;

        public DataRowBuilder GetrowBuilder()
        {
            return rowBuilder1;
        }

        public void SetrowBuilder(DataRowBuilder value)
        {
            rowBuilder1 = value;
        }

        public IDataView Dataview { get => dataview; set => dataview = value; }
        public TransformsCatalog Catalog { get => catalog; set => catalog = value; }
        public MLContext Context { get => context; set => context = value; }

        public Differential(MLContext context, long rowC, IDataView dwp)
        {
            Context = context;
            context.Clustering.Evaluate(Dataview,DataColumn.ToString(),"pixels", "comp1");

            // create columns and rows here
            context.Data.TakeRows(dwp, rowC);

            // focus on a differential algo

            context.Regression.Evaluate(InputData.Datar1.Load(InputData.Stream),
                InputOutputColumnPair.OutputColumnName, 
                InputOutputColumnPair.InputColumnName);
        }
    }
}
