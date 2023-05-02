namespace src.DAL.Influx.Samples
{
    public class NumericSample: Sample {
        public override Boolean AsBoolean(){
            return Convert.ToBoolean(Value);
        }
           public override Double AsNumeric(){
            return Convert.ToDouble(Value);
        }
    }
}
