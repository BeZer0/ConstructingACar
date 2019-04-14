using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConstructingACar.Tests {

    [TestFixture]
    public class Car3RealTests {
        [Test]
        public void TestRealAndDrivingTimeBeforeStarting() {
            var car = new Car();

            Assert.AreEqual(0, car.onBoardComputerDisplay.TripRealTime, "Wrong Trip-Real-Time!");
            Assert.AreEqual(0, car.onBoardComputerDisplay.TripDrivingTime, "Wrong Trip-Driving-Time!");
            Assert.AreEqual(0, car.onBoardComputerDisplay.TotalRealTime, "Wrong Total-Real-Time!");
            Assert.AreEqual(0, car.onBoardComputerDisplay.TotalDrivingTime, "Wrong Total-Driving-Time!");
        }

        [Test]
        public void TestRealAndDrivingTimeBeforeStartingAfterRefueling() {
            var car = new Car();

            car.Refuel(10);

            Assert.AreEqual(0, car.onBoardComputerDisplay.TripRealTime, "Wrong Trip-Real-Time!");
            Assert.AreEqual(0, car.onBoardComputerDisplay.TripDrivingTime, "Wrong Trip-Driving-Time!");
            Assert.AreEqual(0, car.onBoardComputerDisplay.TotalRealTime, "Wrong Total-Real-Time!");
            Assert.AreEqual(0, car.onBoardComputerDisplay.TotalDrivingTime, "Wrong Total-Driving-Time!");
        }

        [Test]
        public void TestRealAndDrivingTimeBeforeStartingAccelerateTo10() {
            var car = new Car();

            car.Accelerate(10);

            Assert.AreEqual(0, car.onBoardComputerDisplay.TripRealTime, "Wrong Trip-Real-Time!");
            Assert.AreEqual(0, car.onBoardComputerDisplay.TripDrivingTime, "Wrong Trip-Driving-Time!");
            Assert.AreEqual(0, car.onBoardComputerDisplay.TotalRealTime, "Wrong Total-Real-Time!");
            Assert.AreEqual(0, car.onBoardComputerDisplay.TotalDrivingTime, "Wrong Total-Driving-Time!");
        }

        [Test]
        public void TestRealAndDrivingTimeBeforeStartingBrakeBy10() {
            var car = new Car();

            car.BrakeBy(10);

            Assert.AreEqual(0, car.onBoardComputerDisplay.TripRealTime, "Wrong Trip-Real-Time!");
            Assert.AreEqual(0, car.onBoardComputerDisplay.TripDrivingTime, "Wrong Trip-Driving-Time!");
            Assert.AreEqual(0, car.onBoardComputerDisplay.TotalRealTime, "Wrong Total-Real-Time!");
            Assert.AreEqual(0, car.onBoardComputerDisplay.TotalDrivingTime, "Wrong Total-Driving-Time!");
        }

        [Test]
        public void TestRealAndDrivingTimeBeforeStartingFreeWheel() {
            var car = new Car();

            car.FreeWheel();

            Assert.AreEqual(0, car.onBoardComputerDisplay.TripRealTime, "Wrong Trip-Real-Time!");
            Assert.AreEqual(0, car.onBoardComputerDisplay.TripDrivingTime, "Wrong Trip-Driving-Time!");
            Assert.AreEqual(0, car.onBoardComputerDisplay.TotalRealTime, "Wrong Total-Real-Time!");
            Assert.AreEqual(0, car.onBoardComputerDisplay.TotalDrivingTime, "Wrong Total-Driving-Time!");
        }

        [Test]
        public void TestRealAndDrivingTimeBeforeStartingRunningIdl() {
            var car = new Car();

            car.RunningIdle();

            Assert.AreEqual(0, car.onBoardComputerDisplay.TripRealTime, "Wrong Trip-Real-Time!");
            Assert.AreEqual(0, car.onBoardComputerDisplay.TripDrivingTime, "Wrong Trip-Driving-Time!");
            Assert.AreEqual(0, car.onBoardComputerDisplay.TotalRealTime, "Wrong Total-Real-Time!");
            Assert.AreEqual(0, car.onBoardComputerDisplay.TotalDrivingTime, "Wrong Total-Driving-Time!");
        }

        [Test]
        public void TestRealAndDrivingTimeAfterRunningIdle() {
            var car = new Car();

            car.EngineStart();

            car.RunningIdle();
            car.RunningIdle();

            Assert.AreEqual(3, car.onBoardComputerDisplay.TripRealTime, "Wrong Trip-Real-Time!");
            Assert.AreEqual(0, car.onBoardComputerDisplay.TripDrivingTime, "Wrong Trip-Driving-Time!");
            Assert.AreEqual(3, car.onBoardComputerDisplay.TotalRealTime, "Wrong Total-Real-Time!");
            Assert.AreEqual(0, car.onBoardComputerDisplay.TotalDrivingTime, "Wrong Total-Driving-Time!");
        }

        [Test]
        public void TestRealAndDrivingTimeAfterDriving() {
            var car = new Car();

            car.EngineStart();

            car.RunningIdle();
            car.RunningIdle();

            car.Accelerate(30);
            car.Accelerate(30);
            car.Accelerate(30);
            car.Accelerate(30);
            car.Accelerate(30);

            car.BrakeBy(10);
            car.BrakeBy(10);

            car.Accelerate(30);

            Assert.AreEqual(11, car.onBoardComputerDisplay.TripRealTime, "Wrong Trip-Real-Time!");
            Assert.AreEqual(8, car.onBoardComputerDisplay.TripDrivingTime, "Wrong Trip-Driving-Time!");
            Assert.AreEqual(11, car.onBoardComputerDisplay.TotalRealTime, "Wrong Total-Real-Time!");
            Assert.AreEqual(8, car.onBoardComputerDisplay.TotalDrivingTime, "Wrong Total-Driving-Time!");
        }

        [Test]
        public void TestDrivingTimeAfterDrivingWithEngineRestart() {
            var car = new Car();

            car.EngineStart();

            car.RunningIdle();
            car.RunningIdle();

            car.Accelerate(30);
            car.Accelerate(30);
            car.Accelerate(30);

            car.BrakeBy(10);
            car.BrakeBy(10);
            car.BrakeBy(10);

            Assert.AreEqual(9, car.onBoardComputerDisplay.TripRealTime, "Wrong Trip-Real-Time!");
            Assert.AreEqual(5, car.onBoardComputerDisplay.TripDrivingTime, "Wrong Trip-Driving-Time!");
            Assert.AreEqual(9, car.onBoardComputerDisplay.TotalRealTime, "Wrong Total-Real-Time!");
            Assert.AreEqual(5, car.onBoardComputerDisplay.TotalDrivingTime, "Wrong Total-Driving-Time!");

            car.EngineStop();

            car.Refuel(10);

            car.EngineStart();

            car.Accelerate(30);
            car.Accelerate(30);

            car.BrakeBy(10);
            car.BrakeBy(10);

            car.Accelerate(30);

            Assert.AreEqual(6, car.onBoardComputerDisplay.TripRealTime, "Wrong Trip-Real-Time!");
            Assert.AreEqual(4, car.onBoardComputerDisplay.TripDrivingTime, "Wrong Trip-Driving-Time!");
            Assert.AreEqual(16, car.onBoardComputerDisplay.TotalRealTime, "Wrong Total-Real-Time!");
            Assert.AreEqual(9, car.onBoardComputerDisplay.TotalDrivingTime, "Wrong Total-Driving-Time!");
        }

        [Test]
        public void TestDrivingTimeAfterDrivingAfterReset() {
            var car = new Car();

            car.EngineStart();

            car.RunningIdle();
            car.RunningIdle();

            car.Accelerate(30);
            car.Accelerate(30);
            car.Accelerate(30);

            car.BrakeBy(10);
            car.BrakeBy(10);
            car.BrakeBy(10);

            car.onBoardComputerDisplay.TripReset();
            car.onBoardComputerDisplay.TotalReset();

            Assert.AreEqual(0, car.onBoardComputerDisplay.TripRealTime, "Wrong Trip-Real-Time!");
            Assert.AreEqual(0, car.onBoardComputerDisplay.TripDrivingTime, "Wrong Trip-Driving-Time!");
            Assert.AreEqual(0, car.onBoardComputerDisplay.TotalRealTime, "Wrong Total-Real-Time!");
            Assert.AreEqual(0, car.onBoardComputerDisplay.TotalDrivingTime, "Wrong Total-Driving-Time!");
        }

        [Test]
        public void TestActualSpeedBeforeDriving() {
            var car = new Car();

            car.EngineStart();

            car.RunningIdle();
            car.RunningIdle();

            Assert.AreEqual(0, car.onBoardComputerDisplay.ActualSpeed, "Wrong actual speed.");
        }

        [Test]
        public void TestActualSpeedWhenDriving() {
            var car = new Car();

            car.EngineStart();

            car.Accelerate(30);
            car.Accelerate(30);
            car.Accelerate(30);

            Assert.AreEqual(30, car.onBoardComputerDisplay.ActualSpeed, "Wrong actual speed.");
        }

        [Test]
        public void TestAverageSpeed1() {
            var car = new Car();

            car.EngineStart();

            car.RunningIdle();
            car.RunningIdle();

            car.Accelerate(30);
            car.Accelerate(30);
            car.Accelerate(30);

            car.BrakeBy(10);
            car.BrakeBy(10);
            car.BrakeBy(10);

            Assert.AreEqual(18, car.onBoardComputerDisplay.TripAverageSpeed, "Wrong Trip-Average-Speed.");
            Assert.AreEqual(18, car.onBoardComputerDisplay.TotalAverageSpeed, "Wrong Total-Average-Speed.");
        }

        [Test]
        public void TestAverageSpeed2() {
            var car = new Car();

            car.EngineStart();

            car.RunningIdle();
            car.RunningIdle();

            car.Accelerate(30);
            car.Accelerate(30);
            car.Accelerate(30);
            car.Accelerate(30);
            car.Accelerate(30);

            car.BrakeBy(10);
            car.BrakeBy(10);
            car.BrakeBy(10);

            Assert.AreEqual(21.4, car.onBoardComputerDisplay.TripAverageSpeed, "Wrong Trip-Average-Speed.");
            Assert.AreEqual(21.4, car.onBoardComputerDisplay.TotalAverageSpeed, "Wrong Total-Average-Speed.");
        }

        [Test]
        public void TestAverageSpeedAfterEngineRestart() {
            var car = new Car();

            car.EngineStart();

            car.RunningIdle();
            car.RunningIdle();

            car.Accelerate(30);
            car.Accelerate(30);
            car.Accelerate(30);
            car.Accelerate(30);
            car.Accelerate(30);

            car.BrakeBy(10);
            car.BrakeBy(10);
            car.BrakeBy(10);

            car.EngineStop();

            car.EngineStart();

            car.Accelerate(20);

            car.Accelerate(20);

            Assert.AreEqual(15, car.onBoardComputerDisplay.TripAverageSpeed, "Wrong Trip-Average-Speed.");
            Assert.AreEqual(20, car.onBoardComputerDisplay.TotalAverageSpeed, "Wrong Total-Average-Speed.");
        }

        [Test]
        public void TestAverageSpeedAfterTripReset() {
            var car = new Car();

            car.EngineStart();

            car.RunningIdle();
            car.RunningIdle();

            car.Accelerate(30);
            car.Accelerate(30);
            car.Accelerate(30);
            car.Accelerate(30);
            car.Accelerate(30);

            car.BrakeBy(10);
            car.BrakeBy(10);
            car.BrakeBy(10);

            car.onBoardComputerDisplay.TripReset();

            car.Accelerate(20);

            car.Accelerate(20);

            Assert.AreEqual(15, car.onBoardComputerDisplay.TripAverageSpeed, "Wrong Trip-Average-Speed.");
            Assert.AreEqual(20, car.onBoardComputerDisplay.TotalAverageSpeed, "Wrong Total-Average-Speed.");
        }

        [Test]
        public void TestActualConsumptionEngineStart() {
            var car = new Car();

            car.EngineStart();

            Assert.AreEqual(0, car.onBoardComputerDisplay.ActualConsumptionByTime, "Wrong Actual-Consumption-By-Time");
            Assert.AreEqual(double.NaN, car.onBoardComputerDisplay.ActualConsumptionByDistance, "Wrong Actual-Consumption-By-Distance");
        }

        [Test]
        public void TestActualConsumptionEngineStartAfterDriving() {
            var car = new Car();

            car.EngineStart();

            car.Accelerate(10);

            car.BrakeBy(10);

            car.EngineStop();

            car.EngineStart();

            Assert.AreEqual(0, car.onBoardComputerDisplay.ActualConsumptionByTime, "Wrong Actual-Consumption-By-Time");
            Assert.AreEqual(double.NaN, car.onBoardComputerDisplay.ActualConsumptionByDistance, "Wrong Actual-Consumption-By-Distance");
        }

        [Test]
        public void TestActualConsumptionEngineStopAfterDriving() {
            var car = new Car();

            car.EngineStart();

            car.Accelerate(10);

            car.BrakeBy(10);

            car.EngineStop();

            Assert.AreEqual(0, car.onBoardComputerDisplay.ActualConsumptionByTime, "Wrong Actual-Consumption-By-Time");
            Assert.AreEqual(double.NaN, car.onBoardComputerDisplay.ActualConsumptionByDistance, "Wrong Actual-Consumption-By-Distance");
        }

        [Test]
        public void TestActualConsumptionRunningIdle() {
            var car = new Car();

            car.EngineStart();

            car.RunningIdle();

            Assert.AreEqual(0.0003, car.onBoardComputerDisplay.ActualConsumptionByTime, "Wrong Actual-Consumption-By-Time");
            Assert.AreEqual(double.NaN, car.onBoardComputerDisplay.ActualConsumptionByDistance, "Wrong Actual-Consumption-By-Distance");
        }

        [Test]
        public void TestActualConsumptionAccelerateTo10() {
            var car = new Car();

            car.EngineStart();

            car.Accelerate(10);

            Assert.AreEqual(0.0020, car.onBoardComputerDisplay.ActualConsumptionByTime, "Wrong Actual-Consumption-By-Time");
            Assert.AreEqual(72, car.onBoardComputerDisplay.ActualConsumptionByDistance, "Wrong Actual-Consumption-By-Distance");
        }

        [Test]
        public void TestActualConsumptionAccelerateTo100() {
            var car = new Car(40, 20);

            car.EngineStart();

            car.Accelerate(100);
            car.Accelerate(100);
            car.Accelerate(100);
            car.Accelerate(100);
            car.Accelerate(100);

            Assert.AreEqual(0.0014, car.onBoardComputerDisplay.ActualConsumptionByTime, "Wrong Actual-Consumption-By-Time");
            Assert.AreEqual(5, car.onBoardComputerDisplay.ActualConsumptionByDistance, "Wrong Actual-Consumption-By-Distance");
        }

        [Test]
        public void TestActualConsumptionBrakeBy() {
            var car = new Car(40, 20);

            car.EngineStart();

            car.Accelerate(100);
            car.Accelerate(100);
            car.Accelerate(100);
            car.Accelerate(100);
            car.Accelerate(100);

            car.BrakeBy(10);

            Assert.AreEqual(0, car.onBoardComputerDisplay.ActualConsumptionByTime, "Wrong Actual-Consumption-By-Time");
            Assert.AreEqual(0, car.onBoardComputerDisplay.ActualConsumptionByDistance, "Wrong Actual-Consumption-By-Distance");
        }

        [Test]
        public void TestActualConsumptionFreeWheel() {
            var car = new Car(40, 20);

            car.EngineStart();

            car.Accelerate(100);
            car.Accelerate(100);
            car.Accelerate(100);
            car.Accelerate(100);
            car.Accelerate(100);

            car.FreeWheel();

            Assert.AreEqual(0, car.onBoardComputerDisplay.ActualConsumptionByTime, "Wrong Actual-Consumption-By-Time");
            Assert.AreEqual(0, car.onBoardComputerDisplay.ActualConsumptionByDistance, "Wrong Actual-Consumption-By-Distance");
        }

        [Test]
        public void TestAverageConsumptionsBeforeEngineStart() {
            var car = new Car();

            Assert.AreEqual(0, car.onBoardComputerDisplay.TripAverageConsumptionByTime, "Wrong Trip-Average-Consumption-By-Time");
            Assert.AreEqual(0, car.onBoardComputerDisplay.TotalAverageConsumptionByTime, "Wrong Total-Average-Consumption-By-Time");
            Assert.AreEqual(0, car.onBoardComputerDisplay.TripAverageConsumptionByDistance, "Wrong Trip-Average-Consumption-By-Distance");
            Assert.AreEqual(0, car.onBoardComputerDisplay.TotalAverageConsumptionByDistance, "Wrong Total-Average-Consumption-By-Distance");
        }

        [Test]
        public void TestAverageConsumptionsAfterEngineStart() {
            var car = new Car();

            car.EngineStart();

            Assert.AreEqual(0, car.onBoardComputerDisplay.TripAverageConsumptionByTime, "Wrong Trip-Average-Consumption-By-Time");
            Assert.AreEqual(0, car.onBoardComputerDisplay.TotalAverageConsumptionByTime, "Wrong Total-Average-Consumption-By-Time");
            Assert.AreEqual(0, car.onBoardComputerDisplay.TripAverageConsumptionByDistance, "Wrong Trip-Average-Consumption-By-Distance");
            Assert.AreEqual(0, car.onBoardComputerDisplay.TotalAverageConsumptionByDistance, "Wrong Total-Average-Consumption-By-Distance");
        }

        [Test]
        public void TestAverageConsumptionsAfterAccelerating() {
            var car = new Car();

            car.EngineStart();

            car.Accelerate(30);
            car.Accelerate(30);
            car.Accelerate(30);

            Assert.AreEqual(0.0015, car.onBoardComputerDisplay.TripAverageConsumptionByTime, "Wrong Trip-Average-Consumption-By-Time");
            Assert.AreEqual(0.0015, car.onBoardComputerDisplay.TotalAverageConsumptionByTime, "Wrong Total-Average-Consumption-By-Time");
            Assert.AreEqual(44, car.onBoardComputerDisplay.TripAverageConsumptionByDistance, "Wrong Trip-Average-Consumption-By-Distance");
            Assert.AreEqual(44, car.onBoardComputerDisplay.TotalAverageConsumptionByDistance, "Wrong Total-Average-Consumption-By-Distance");
        }

        [Test]
        public void TestAverageConsumptionsAfterAcceleratingAndReset() {
            var car = new Car();

            car.EngineStart();

            car.Accelerate(30);
            car.Accelerate(30);
            car.Accelerate(30);

            car.onBoardComputerDisplay.TripReset();

            Assert.AreEqual(0, car.onBoardComputerDisplay.TripAverageConsumptionByTime, "Wrong Trip-Average-Consumption-By-Time");
            Assert.AreEqual(0.0015, car.onBoardComputerDisplay.TotalAverageConsumptionByTime, "Wrong Total-Average-Consumption-By-Time");
            Assert.AreEqual(0, car.onBoardComputerDisplay.TripAverageConsumptionByDistance, "Wrong Trip-Average-Consumption-By-Distance");
            Assert.AreEqual(44, car.onBoardComputerDisplay.TotalAverageConsumptionByDistance, "Wrong Total-Average-Consumption-By-Distance");

            car.Accelerate(30);
            car.Accelerate(30);
            car.Accelerate(30);

            car.onBoardComputerDisplay.TotalReset();

            Assert.AreEqual(0.002, car.onBoardComputerDisplay.TripAverageConsumptionByTime, "Wrong Trip-Average-Consumption-By-Time");
            Assert.AreEqual(0, car.onBoardComputerDisplay.TotalAverageConsumptionByTime, "Wrong Total-Average-Consumption-By-Time");
            Assert.AreEqual(24, car.onBoardComputerDisplay.TripAverageConsumptionByDistance, "Wrong Trip-Average-Consumption-By-Distance");
            Assert.AreEqual(0, car.onBoardComputerDisplay.TotalAverageConsumptionByDistance, "Wrong Total-Average-Consumption-By-Distance");
        }

        [Test]
        public void TestAverageConsumptionsAfterBraking() {
            var car = new Car();

            car.EngineStart();

            car.Accelerate(30);
            car.Accelerate(30);
            car.Accelerate(30);

            car.BrakeBy(10);
            car.BrakeBy(10);
            car.BrakeBy(10);

            Assert.AreEqual(0.0009, car.onBoardComputerDisplay.TripAverageConsumptionByTime, "Wrong Trip-Average-Consumption-By-Time");
            Assert.AreEqual(0.0009, car.onBoardComputerDisplay.TotalAverageConsumptionByTime, "Wrong Total-Average-Consumption-By-Time");
            Assert.AreEqual(26.4, car.onBoardComputerDisplay.TripAverageConsumptionByDistance, "Wrong Trip-Average-Consumption-By-Distance");
            Assert.AreEqual(26.4, car.onBoardComputerDisplay.TotalAverageConsumptionByDistance, "Wrong Total-Average-Consumption-By-Distance");
        }

        [Test]
        public void TestAverageConsumptionsAfterRunningIdle() {
            var car = new Car();

            car.EngineStart();

            car.Accelerate(10);
            car.BrakeBy(5);
            car.BrakeBy(5);

            car.RunningIdle();
            car.RunningIdle();
            car.RunningIdle();

            Assert.AreEqual(0.00046, car.onBoardComputerDisplay.TripAverageConsumptionByTime, "Wrong Trip-Average-Consumption-By-Time");
            Assert.AreEqual(0.00046, car.onBoardComputerDisplay.TotalAverageConsumptionByTime, "Wrong Total-Average-Consumption-By-Time");
            Assert.AreEqual(36, car.onBoardComputerDisplay.TripAverageConsumptionByDistance, "Wrong Trip-Average-Consumption-By-Distance");
            Assert.AreEqual(36, car.onBoardComputerDisplay.TotalAverageConsumptionByDistance, "Wrong Total-Average-Consumption-By-Distance");
        }

        [Test]
        public void TestDrivenDistancesBeforeEngineStart() {
            var car = new Car();

            Assert.AreEqual(0, car.onBoardComputerDisplay.TripDrivenDistance, "Wrong Trip-Driven-Distance.");
            Assert.AreEqual(0, car.onBoardComputerDisplay.TotalDrivenDistance, "Wrong Total-Driven-Distance.");
        }

        [Test]
        public void TestDrivenDistancesAfterEngineStart() {
            var car = new Car();

            car.EngineStart();

            Assert.AreEqual(0, car.onBoardComputerDisplay.TripDrivenDistance, "Wrong Trip-Driven-Distance.");
            Assert.AreEqual(0, car.onBoardComputerDisplay.TotalDrivenDistance, "Wrong Total-Driven-Distance.");
        }

        [Test]
        public void TestDrivenDistancesAfterRunningIdle() {
            var car = new Car();

            car.EngineStart();

            Enumerable.Range(0, 200).ToList().ForEach(c => car.RunningIdle());

            Assert.AreEqual(0, car.onBoardComputerDisplay.TripDrivenDistance, "Wrong Trip-Driven-Distance.");
            Assert.AreEqual(0, car.onBoardComputerDisplay.TotalDrivenDistance, "Wrong Total-Driven-Distance.");
        }

        [Test]
        public void TestDrivenDistancesAfterAccelerating() {
            var car = new Car();

            car.EngineStart();

            Enumerable.Range(0, 30).ToList().ForEach(c => car.Accelerate(30));

            Assert.AreEqual(0.24, car.onBoardComputerDisplay.TripDrivenDistance, "Wrong Trip-Driven-Distance.");
            Assert.AreEqual(0.24, car.onBoardComputerDisplay.TotalDrivenDistance, "Wrong Total-Driven-Distance.");
        }

        [Test]
        public void TestDrivenDistancesAfterDriving() {
            var car = new Car();

            car.EngineStart();

            Enumerable.Range(0, 30).ToList().ForEach(c => car.Accelerate(100));

            car.BrakeBy(10);
            car.BrakeBy(10);

            car.Accelerate(100);
            car.Accelerate(100);

            Assert.AreEqual(0.81, car.onBoardComputerDisplay.TripDrivenDistance, "Wrong Trip-Driven-Distance.");
            Assert.AreEqual(0.81, car.onBoardComputerDisplay.TotalDrivenDistance, "Wrong Total-Driven-Distance.");
        }

        [Test]
        public void TestDrivenDistancesAfterDrivingAndResets() {
            var car = new Car();

            car.EngineStart();

            Enumerable.Range(0, 30).ToList().ForEach(c => car.Accelerate(100));

            car.BrakeBy(10);
            car.BrakeBy(10);

            car.Accelerate(100);
            car.Accelerate(100);

            car.BrakeBy(10);

            car.onBoardComputerDisplay.TripReset();

            Assert.AreEqual(0, car.onBoardComputerDisplay.TripDrivenDistance, "Wrong Trip-Driven-Distance.");
            Assert.AreEqual(0.83, car.onBoardComputerDisplay.TotalDrivenDistance, "Wrong Total-Driven-Distance.");

            Enumerable.Range(0, 10).ToList().ForEach(c => car.Accelerate(100));

            car.onBoardComputerDisplay.TotalReset();

            Assert.AreEqual(0.28, car.onBoardComputerDisplay.TripDrivenDistance, "Wrong Trip-Driven-Distance.");
            Assert.AreEqual(0, car.onBoardComputerDisplay.TotalDrivenDistance, "Wrong Total-Driven-Distance.");
        }

        [Test]
        public void TestEstimatedRangeBeforeDriving() {
            var car = new Car();

            car.EngineStart();

            Assert.AreEqual(417, car.onBoardComputerDisplay.EstimatedRange, "Wrong Estimated-Range.");
        }

        [Test]
        public void TestEstimatedRangeAfterDrivingSlowSpeedForLowerThan100Seconds() {
            var car = new Car();

            car.EngineStart();

            Enumerable.Range(0, 50).ToList().ForEach(c => car.Accelerate(30));

            Assert.AreEqual(133, car.onBoardComputerDisplay.EstimatedRange, "Wrong Estimated-Range.");
        }

        [Test]
        public void TestEstimatedRangeAfterDrivingOptimumSpeedForLowerThan100Seconds() {
            var car = new Car();

            car.EngineStart();

            Enumerable.Range(0, 50).ToList().ForEach(c => car.Accelerate(100));

            Assert.AreEqual(310, car.onBoardComputerDisplay.EstimatedRange, "Wrong Estimated-Range.");
        }

        [Test]
        public void TestEstimatedRangeAfterDrivingOptimumSpeedForMoreThan100Seconds() // Example Test
        {
            var car = new Car();

            car.EngineStart();

            Enumerable.Range(0, 150).ToList().ForEach(c => car.Accelerate(100));

            Assert.AreEqual(393, car.onBoardComputerDisplay.EstimatedRange, "Wrong Estimated-Range.");
        }

        [Test]
        public void TestEstimatedRangeAfterDrivingMaxSpeed() {
            var car = new Car();

            car.EngineStart();

            Enumerable.Range(0, 150).ToList().ForEach(c => car.Accelerate(250));

            Assert.AreEqual(453, car.onBoardComputerDisplay.EstimatedRange, "Wrong Estimated-Range.");
        }

        [Test]
        public void TestEstimatedRangeAfterDrivingMaxSpeedAndReset() {
            var car = new Car();

            car.EngineStart();

            Enumerable.Range(0, 75).ToList().ForEach(c => car.Accelerate(100));

            car.onBoardComputerDisplay.TripReset();
            car.onBoardComputerDisplay.TotalReset();

            Enumerable.Range(0, 75).ToList().ForEach(c => car.Accelerate(100));

            Assert.AreEqual(393, car.onBoardComputerDisplay.EstimatedRange, "Wrong Estimated-Range.");
        }

        [Test]
        public void Car3RandomTests() {
            var rand = new Random();

            for (int i = 0; i < 20; i++) {
                var car = new Car();

                car.EngineStart();

                double fuelLevel = 20;

                double expectedDrivenDistance = 0;

                double expectedTripAverageConsumptionByTime = 0;

                double expectedTotalAverageConsumptionByTime = 0;

                double expectedTripAverageConsumptionByDistance = 0;

                double expectedTotalAverageConsumptionByDistance = 0;

                var consumptionLast100Seconds = new Queue<double>();
                Enumerable.Range(0, 100).ToList().ForEach(r => consumptionLast100Seconds.Enqueue(4.8));

                var countAcceleratingSeconds = rand.Next(4, 20);
                var accelerateSpeed = rand.Next(21, 31);

                Enumerable.Range(0, countAcceleratingSeconds).ToList().ForEach(
                    r =>
                    {
                        car.Accelerate(accelerateSpeed);
                        consumptionLast100Seconds.Dequeue();
                        int speed = accelerateSpeed;
                        if (r == 0) {
                            speed = 10;
                        }

                        if (r == 1) {
                            speed = 20;
                        }

                        expectedDrivenDistance += speed;
                        consumptionLast100Seconds.Enqueue(((double)200) / speed * 3.6);
                        fuelLevel -= 0.002;

                        expectedTripAverageConsumptionByTime = expectedTripAverageConsumptionByTime
                                    - ((expectedTripAverageConsumptionByTime - 0.002) / (r + 2));

                        expectedTotalAverageConsumptionByTime = expectedTotalAverageConsumptionByTime
                                        - ((expectedTotalAverageConsumptionByTime - 0.002) / (r + 2));

                        var actualConsumptionByDistance = 0.002 / speed * 3600 * 100;

                        expectedTripAverageConsumptionByDistance = expectedTripAverageConsumptionByDistance
                                        - ((expectedTripAverageConsumptionByDistance - actualConsumptionByDistance) / (r + 1));

                        expectedTotalAverageConsumptionByDistance = expectedTotalAverageConsumptionByDistance
                                                        - ((expectedTotalAverageConsumptionByDistance - actualConsumptionByDistance) / (r + 1));
                    });

                Assert.AreEqual(accelerateSpeed, car.onBoardComputerDisplay.ActualSpeed, "Wrong actual speed");
                Assert.AreEqual(0.002, car.onBoardComputerDisplay.ActualConsumptionByTime, "Wrong Actual-Consumption-By-Time");

                var expectetActualConsumptionByDistance = Math.Round(0.002 / accelerateSpeed * 3600 * 100, 1);
                Assert.AreEqual(expectetActualConsumptionByDistance, car.onBoardComputerDisplay.ActualConsumptionByDistance, "Wrong Actual-Consumption-By-Distance");

                Assert.AreEqual(Math.Round(expectedTripAverageConsumptionByTime, 5), car.onBoardComputerDisplay.TripAverageConsumptionByTime, "Wrong Trip-Average-Consumption-By-Time");
                Assert.AreEqual(Math.Round(expectedTotalAverageConsumptionByTime, 5), car.onBoardComputerDisplay.TotalAverageConsumptionByTime, "Wrong Total-Average-Consumption-By-Time");

                Assert.AreEqual(Math.Round(expectedTripAverageConsumptionByDistance, 1), car.onBoardComputerDisplay.TripAverageConsumptionByDistance, "Wrong Trip-Average-Consumption-By-Distance");
                Assert.AreEqual(Math.Round(expectedTotalAverageConsumptionByDistance, 1), car.onBoardComputerDisplay.TotalAverageConsumptionByDistance, "Wrong Total-Average-Consumption-By-Distance");

                var expectedAverageSpeed = Math.Round(((((double)countAcceleratingSeconds - 2) * accelerateSpeed) + 30) / countAcceleratingSeconds, 1);

                Assert.AreEqual(expectedAverageSpeed, car.onBoardComputerDisplay.TripAverageSpeed, "Wrong Trip-Average-Speed.");
                Assert.AreEqual(expectedAverageSpeed, car.onBoardComputerDisplay.TotalAverageSpeed, "Wrong Total-Average-Speed.");

                var expectedEstimatedRange = Math.Round(fuelLevel / (consumptionLast100Seconds.Sum() / 100) * 100);

                Assert.AreEqual(expectedEstimatedRange, car.onBoardComputerDisplay.EstimatedRange, "Wrong Estimated-Range.");

                Assert.AreEqual(countAcceleratingSeconds + 1, car.onBoardComputerDisplay.TripRealTime, "Wrong Trip-Real-Time!");
                Assert.AreEqual(countAcceleratingSeconds, car.onBoardComputerDisplay.TripDrivingTime, "Wrong Trip-Driving-Time!");
                Assert.AreEqual(countAcceleratingSeconds + 1, car.onBoardComputerDisplay.TotalRealTime, "Wrong Total-Real-Time!");
                Assert.AreEqual(countAcceleratingSeconds, car.onBoardComputerDisplay.TotalDrivingTime, "Wrong Total-Driving-Time!");

                expectedDrivenDistance = Math.Round(expectedDrivenDistance / 1000 / 3.6, 2);

                Assert.AreEqual(expectedDrivenDistance, car.onBoardComputerDisplay.TripDrivenDistance, "Wrong Trip-Driven-Distance.");
                Assert.AreEqual(expectedDrivenDistance, car.onBoardComputerDisplay.TotalDrivenDistance, "Wrong Total-Driven-Distance.");
            }
        }
    }
}
