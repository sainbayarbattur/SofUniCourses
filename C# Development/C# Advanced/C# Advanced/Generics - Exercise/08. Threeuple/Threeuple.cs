namespace _08_Threeuple
{
    public class Threeuple<T1, T2, T3>
    {
        private T1 t1;
        private T2 t2;
        private T3 t3;

        public Threeuple(T1 t1, T2 t2, T3 t3)
        {
            this.t1 = t1;
            this.t2 = t2;
            this.t3 = t3;
        }

        public override string ToString()
        {
            return $"{t1} -> {t2} -> {t3}";
        }
    }
}
