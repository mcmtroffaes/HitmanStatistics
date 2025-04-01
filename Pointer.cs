namespace HitmanStatistics {
    public class Pointer {
        public int Address { get; private set; }
        public int[] Offsets { get; private set; }

        public Pointer(int add, int[] off) {
            Address = add;
            Offsets = off;
        }
    }
}
