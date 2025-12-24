using Microsoft.ML.Data;
using Microsoft.ML;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Org.BouncyCastle.Crypto.Engines;
using System.IO;
using Org.BouncyCastle.Utilities;


namespace bhtaFramework
{
    public class MLFramework
    {
        public string LbfgsPoissonRegression()
        {
            string tmp = @"

Το LbfgsPoissonRegression είναι ένα μοντέλο μηχανικής μάθησης που χρησιμοποιείται για την πρόβλεψη ποσοτικών δεδομένων με κατανομή Poisson. Είναι ένα μοντέλο γραμμικής παλινδρόμησης που χρησιμοποιεί τη μέθοδο L-BFGS για την εκμάθηση των παραμέτρων του.

Η μέθοδο L-BFGS είναι μια μέθοδος βελτιστοποίησης που είναι αποτελεσματική για την εκμάθηση μοντέλων γραμμικής παλινδρόμησης με μεγάλες ποσότητες δεδομένων. Είναι μια μέθοδος βαθμιαίας προσέγγισης που ξεκινά με μια αρχική εκτίμηση των παραμέτρων του μοντέλου και στη συνέχεια βελτιώνει σταδιακά τις εκτιμήσεις αυτές χρησιμοποιώντας μια σειρά από επαναλήψεις.

Το LbfgsPoissonRegression μπορεί να χρησιμοποιηθεί για την πρόβλεψη ποικίλων τύπων δεδομένων με κατανομή Poisson, όπως:

Ο αριθμός των ατυχημάτων που συμβαίνουν σε μια συγκεκριμένη περιοχή ανά ημέρα
Ο αριθμός των πελατών που επισκέπτονται ένα κατάστημα ανά ώρα
Ο αριθμός των κρουσμάτων μιας ασθένειας ανά μήνα
Το LbfgsPoissonRegression είναι ένα ισχυρό μοντέλο που μπορεί να χρησιμοποιηθεί για την πρόβλεψη ποσοτικών δεδομένων με κατανομή Poisson. Είναι αποτελεσματικό για την εκμάθηση μοντέλων με μεγάλες ποσότητες δεδομένων και μπορεί να χρησιμοποιηθεί για την πρόβλεψη ποικίλων τύπων δεδομένων.

Ακολουθούν μερικά συγκεκριμένα παραδείγματα του τρόπου με τον οποίο μπορεί να χρησιμοποιηθεί το LbfgsPoissonRegression:

Μια εταιρεία ασφάλισης μπορεί να χρησιμοποιήσει το LbfgsPoissonRegression για να προβλέψει τον αριθμό των ζημιών που θα συμβούν σε ένα έτος.
Ένα κατάστημα λιανικής μπορεί να χρησιμοποιήσει το LbfgsPoissonRegression για να προβλέψει τον αριθμό των πωλήσεων που θα πραγματοποιήσει σε μια συγκεκριμένη περίοδο.
Ένα νοσοκομείο μπορεί να χρησιμοποιήσει το LbfgsPoissonRegression για να προβλέψει τον αριθμό των ασθενών που θα νοσηλευτούν σε μια συγκεκριμένη περίοδο.
Το LbfgsPoissonRegression είναι ένα ευέλικτο και ισχυρό μοντέλο που μπορεί να χρησιμοποιηθεί για την πρόβλεψη ποσοτικών δεδομένων με κατανομή Poisson.
(Πηγή AI Gemini)
";
            return tmp;
        }
        public MLFramework() { }

        public class ModelData
        {

            [LoadColumn(0), ColumnName("Label")]
            public float Result { get; set; }

            [LoadColumn(1)]
            public float Filter1 { get; set; }

            [LoadColumn(2)]
            public float Filter2 { get; set; }

            [LoadColumn(3)]
            public float Filter3 { get; set; }

            [LoadColumn(4)]
            public float Filter4 { get; set; }

            [LoadColumn(5)]
            public float Filter5 { get; set; }

            [LoadColumn(6)]
            public float Filter6 { get; set; }

            [LoadColumn(7)]
            public float Filter7 { get; set; }

            [LoadColumn(8)]
            public float Filter8 { get; set; }

            [LoadColumn(9)]
            public float Filter9 { get; set; }

            [LoadColumn(10)]
            public float Filter10 { get; set; }

            [LoadColumn(11)]
            public float Filter11 { get; set; }

            [LoadColumn(12)]
            public float Filter12 { get; set; }

            [LoadColumn(13)]
            public float Filter13 { get; set; }

            [LoadColumn(14)]
            public float Filter14 { get; set; }

            [LoadColumn(15)]
            public float Filter15 { get; set; }

            [LoadColumn(16)]
            public float Filter16 { get; set; }

            [LoadColumn(17)]
            public float Filter17 { get; set; }

            [LoadColumn(18)]
            public float Filter18 { get; set; }

            [LoadColumn(19)]
            public float Filter19 { get; set; }

            [LoadColumn(20)]
            public float Filter20 { get; set; }

        }

        public class ResultPrediction
        {
            [ColumnName("Score")]
            public float PredictedResult { get; set; }
        }

        
        public double Predict(float[] vars, string model, string path = @"C:\inetpub\wwwroot\mySpace.e-iot.eu\mySpace\models\")
        {
            model = path.Trim() + model.Trim();
            //File.WriteAllText("MLModels.log", model);
            var newData = new ModelData();
            for (int i = 0; i < vars.Length; i++)
            {                
                if (i == 0) newData.Filter1 = vars[i];
                if (i == 1) newData.Filter2 = vars[i];
                if (i == 2) newData.Filter3 = vars[i];

                if (i == 3) newData.Filter4 = vars[i];
                if (i == 4) newData.Filter5 = vars[i];
                if (i == 5) newData.Filter6 = vars[i];

                if (i == 6) newData.Filter7 = vars[i];
                if (i == 7) newData.Filter8 = vars[i];
                if (i == 8) newData.Filter9 = vars[i];

                if (i == 9) newData.Filter10 = vars[i];
                if (i == 10) newData.Filter11 = vars[i];
                if (i == 11) newData.Filter12 = vars[i];

                if (i == 12) newData.Filter13 = vars[i];
                if (i == 13) newData.Filter14 = vars[i];
                if (i == 14) newData.Filter15 = vars[i];

                if (i == 15) newData.Filter16 = vars[i];
                if (i == 16) newData.Filter17 = vars[i];
                if (i == 17) newData.Filter19 = vars[i];

                if (i == 18) newData.Filter19 = vars[i];
                if (i == 19) newData.Filter20 = vars[i];
            }

            try
            {
                if (File.Exists(model))
                {
                    
                    var predictionFunc = new MLContext().Model.CreatePredictionEngine<ModelData, ResultPrediction>(Load(model));
                    var prediction = predictionFunc.Predict(newData);
                    return prediction.PredictedResult;
                }
                else 
                    return -1;
            }
            catch (Exception e)
            {
                string tmp = e.Message;
                return -256;
            }
        }

        private ITransformer Load(string modelname = "model.zip")
        {
            DataViewSchema modelSchema;
            try
            {
                ITransformer itr =  new Microsoft.ML.MLContext().Model.Load(modelname, out modelSchema);                
                return itr;
            }
            catch (Exception e) 
            { 
                string tmp = e.Message;
                return new Microsoft.ML.MLContext().Model.Load(modelname, out modelSchema);
            }
        }
         
        public static void WriteCommandFiles(int[] var, int deka, string account, string model, string application, string controller, string pin, string directoryPath = @"\MLCommands")
        {
            // Λήψη όλων των αρχείων στον υποκατάλογο bin\commands
            string filepath = directoryPath+ @"\"+ System.DateTime.Now.ToString("yyyyMMdd_HHmm");
            string lines = @"
vars=@vars
@var
deka=@deka
path=\wwwroot\myspace.e-iot.eu\mySpace\models\@account\
model= @model
application=@application
controller=@controller
pin=@pin
";
            lines=lines.Replace("@vars", var.Length.ToString());
            lines = lines.Replace("@deka", deka.ToString());
            lines = lines.Replace("@account", account);
            lines = lines.Replace("@model", model);
            lines = lines.Replace("@application", application);
            lines = lines.Replace("@controller", controller);
            lines = lines.Replace("@pin", pin);
            string vartmp = "";
            for (int i = 0; i < var.Length; i++)
            {
                vartmp += "var=" +var[i].ToString();
            }
            lines = lines.Replace("@var", vartmp);
            File.WriteAllText(filepath, lines);
        }

        #region Training
        public class TrainingItem
        {
            public double RSquared { get; set; }
            public ITransformer model { get; set; }
            public DataViewSchema Schema { get; set; }
        }

        public double Training(int featuresidx, string modelDataFile, bool save = true, string modelname = "model.zip")
        {
            string[] features = new string[featuresidx];
            for (int i = 0; i < featuresidx; i++)
                features[i] = "Filter" + (i + 1).ToString().Trim();

            MLContext context = new MLContext();
            IDataView trainData = context.Data.LoadFromTextFile<ModelData>(modelDataFile, hasHeader: true, separatorChar: ',');

            var testTrainSplit = context.Data.TrainTestSplit(trainData, testFraction: 0.2);
            var pipeline = context.Transforms.Concatenate("Features", features).Append(context.Regression.Trainers.LbfgsPoissonRegression());                                //  LbfgsPoissonRegression() || OnlineGradientDescent() || Sdca()
            ITransformer model = pipeline.Fit(testTrainSplit.TrainSet);

            var predictions = model.Transform(testTrainSplit.TrainSet);
            var metrics = context.Regression.Evaluate(predictions);

            TrainingItem Item = new TrainingItem();
            Item.RSquared = metrics.RSquared;
            Item.model = model;
            Item.Schema = trainData.Schema;
            if (save) new MLContext().Model.Save(Item.model, Item.Schema, modelname);
            return Item.RSquared;
        }

        public enum RegressionType
        {
            Poisson,
            Linear,
            OnlineGradientDescent
        }
        public double Training(DataTable modelDataFile, bool save = true, string modelname = "model.zip", RegressionType Regration=RegressionType.Poisson, double testfraction_=0.2)
        {
            int featuresidx = modelDataFile.Columns.Count - 1;
            string[] features = new string[featuresidx];
            for (int i = 0; i < featuresidx; i++)
                features[i] = "Filter" + (i + 1).ToString().Trim();

            MLContext context = new MLContext();
            List<ModelData> trainingData = new List<ModelData>();
            for (int i = 0; i < modelDataFile.Rows.Count; i++)
            {
                ModelData md = new ModelData();
                md.Result = (float)Convert.ToDouble(modelDataFile.Rows[i][0]);
                for (int j = 1; j < modelDataFile.Columns.Count; j++)
                {
                    if (j == 1) md.Filter1 = (float)Convert.ToDouble(modelDataFile.Rows[i][j]);
                    if (j == 2) md.Filter2 = (float)Convert.ToDouble(modelDataFile.Rows[i][j]);
                    if (j == 3) md.Filter3 = (float)Convert.ToDouble(modelDataFile.Rows[i][j]);

                    if (j == 4) md.Filter4 = (float)Convert.ToDouble(modelDataFile.Rows[i][j]);
                    if (j == 5) md.Filter5 = (float)Convert.ToDouble(modelDataFile.Rows[i][j]);
                    if (j == 6) md.Filter6 = (float)Convert.ToDouble(modelDataFile.Rows[i][j]);

                    if (j == 7) md.Filter7 = (float)Convert.ToDouble(modelDataFile.Rows[i][j]);
                    if (j == 8) md.Filter8 = (float)Convert.ToDouble(modelDataFile.Rows[i][j]);
                    if (j == 9) md.Filter9 = (float)Convert.ToDouble(modelDataFile.Rows[i][j]);

                    if (j == 10) md.Filter10 = (float)Convert.ToDouble(modelDataFile.Rows[i][j]);
                    if (j == 11) md.Filter11 = (float)Convert.ToDouble(modelDataFile.Rows[i][j]);
                    if (j == 12) md.Filter12 = (float)Convert.ToDouble(modelDataFile.Rows[i][j]);

                    if (j == 13) md.Filter13 = (float)Convert.ToDouble(modelDataFile.Rows[i][j]);
                    if (j == 14) md.Filter14 = (float)Convert.ToDouble(modelDataFile.Rows[i][j]);
                    if (j == 15) md.Filter15 = (float)Convert.ToDouble(modelDataFile.Rows[i][j]);

                    if (j == 16) md.Filter16 = (float)Convert.ToDouble(modelDataFile.Rows[i][j]);
                    if (j == 17) md.Filter17 = (float)Convert.ToDouble(modelDataFile.Rows[i][j]);
                    if (j == 18) md.Filter18 = (float)Convert.ToDouble(modelDataFile.Rows[i][j]);

                    if (j == 19) md.Filter19 = (float)Convert.ToDouble(modelDataFile.Rows[i][j]);
                    if (j == 20) md.Filter20 = (float)Convert.ToDouble(modelDataFile.Rows[i][j]);
                }
                trainingData.Add(md);
            }

            if (Regration == RegressionType.Poisson)
            {
                IDataView trainData;
                trainData = context.Data.LoadFromEnumerable<ModelData>(trainingData);
                var testTrainSplit = context.Data.TrainTestSplit(trainData, testFraction: testfraction_);
                var pipeline = context.Transforms.Concatenate("Features", features).Append(context.Regression.Trainers.LbfgsPoissonRegression());
                ITransformer model = pipeline.Fit(testTrainSplit.TrainSet);
                var predictions = model.Transform(testTrainSplit.TrainSet);
                var metrics = context.Regression.Evaluate(predictions);
                TrainingItem Item = new TrainingItem();
                Item.RSquared = metrics.RSquared;
                Item.model = model;
                Item.Schema = trainData.Schema;
                if (save) new MLContext().Model.Save(Item.model, Item.Schema, modelname);
                return Item.RSquared;
            }
            if (Regration == RegressionType.Linear)
            {
                IDataView trainData;
                trainData = context.Data.LoadFromEnumerable<ModelData>(trainingData);
                var testTrainSplit = context.Data.TrainTestSplit(trainData, testFraction: 0.2);
                var pipeline = context.Transforms.Concatenate("Features", features).Append(context.Regression.Trainers.Sdca());
                ITransformer model = pipeline.Fit(testTrainSplit.TrainSet);
                var predictions = model.Transform(testTrainSplit.TestSet);
                var metrics = context.Regression.Evaluate(predictions);
                TrainingItem item = new TrainingItem();
                item.RSquared = metrics.RSquared;
                item.model = model;
                item.Schema = trainData.Schema;
                if (save) context.Model.Save(item.model, item.Schema, modelname);
                return item.RSquared;
            }
            if(Regration== RegressionType.OnlineGradientDescent) {
                IDataView trainData; 
                trainData = context.Data.LoadFromEnumerable<ModelData>(trainingData); 
                var testTrainSplit = context.Data.TrainTestSplit(trainData, testFraction: 0.2); 
                var pipeline = context.Transforms.Concatenate("Features", features).Append(context.Regression.Trainers.OnlineGradientDescent()); 
                ITransformer model = pipeline.Fit(testTrainSplit.TrainSet); 
                var predictions = model.Transform(testTrainSplit.TestSet); 
                var metrics = context.Regression.Evaluate(predictions);
                TrainingItem item = new TrainingItem();
                item.RSquared = metrics.RSquared;
                item.model = model;
                item.Schema = trainData.Schema;
                if (save) context.Model.Save(item.model, item.Schema, modelname);
                return item.RSquared;
            }

            return (double)0;
        }

        #endregion

        #region "Aux"
            public DataTable GetTable(int i)
            {
                DataTable dataTable = new DataTable();
                dataTable.Columns.Add("Result", typeof(float));
                for (int j = 0; j < i; j++)
                    dataTable.Columns.Add("Filter" + j.ToString(), typeof(float));
                return dataTable;
            }
        #endregion

    }
}
