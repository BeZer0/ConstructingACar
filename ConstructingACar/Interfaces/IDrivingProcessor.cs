namespace ConstructingACar {

    public interface IDrivingProcessor {
        double ActualConsumption { get; }
        int ActualSpeed { get; }
        void EngineStart();
        void EngineStop();
        void IncreaseSpeedTo(int speed);
        void ReduceSpeed(int speed);
    }
}
