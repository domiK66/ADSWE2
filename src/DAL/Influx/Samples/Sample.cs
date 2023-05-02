namespace src.DAL.Influx.Samples
{
    public abstract class Sample {
        public String Tag {get; set;}
        public DateTime Timestamp{get; set;}
        public Object Value{get; set;}

        public abstract Boolean AsBoolean();
        public abstract Double AsNumeric();

        internal byte AsFloat()
        {
            throw new NotImplementedException();
        }
    }
}

