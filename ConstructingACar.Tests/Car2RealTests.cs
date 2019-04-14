using NUnit.Framework;
using System;
using System.Linq;

namespace ConstructingACar.Tests {

    [TestFixture]
    public class Car2RealTests {
        [Test]
        public void TestStartSpeed() {
            var car = new Car();

            car.EngineStart();

            Assert.AreEqual(0, car.drivingInformationDisplay.ActualSpeed, "Wrong actual speed!");
        }

        [Test]
        public void TestFreeWheelNoSpeedReduceWhenNoMoving() {
            var car = new Car();

            car.EngineStart();

            Assert.AreEqual(0, car.drivingInformationDisplay.ActualSpeed, "Wrong actual speed!");

            car.FreeWheel();

            Assert.AreEqual(0, car.drivingInformationDisplay.ActualSpeed, "Wrong actual speed!");
        }

        [Test]
        public void TestFreeWheelSpeed() {
            var car = new Car();

            car.EngineStart();

            Enumerable.Range(0, 10).ToList().ForEach(s => car.Accelerate(100));

            Assert.AreEqual(100, car.drivingInformationDisplay.ActualSpeed, "Wrong actual speed!");

            car.FreeWheel();
            car.FreeWheel();
            car.FreeWheel();

            Assert.AreEqual(97, car.drivingInformationDisplay.ActualSpeed, "Wrong actual speed!");
        }

        [Test]
        public void TestMaxAccelerationOutOfRange() {
            var car = new Car(20, 25);

            car.EngineStart();

            car.Accelerate(21);

            Assert.AreEqual(20, car.drivingInformationDisplay.ActualSpeed, "Wrong actual speed!");

            car = new Car(20, 0);

            car.EngineStart();

            car.Accelerate(6);

            Assert.AreEqual(5, car.drivingInformationDisplay.ActualSpeed, "Wrong actual speed!");

            car = new Car(20, -10);

            car.EngineStart();

            car.Accelerate(6);

            Assert.AreEqual(5, car.drivingInformationDisplay.ActualSpeed, "Wrong actual speed!");
        }

        [Test]
        public void TestAccelerateBy10() {
            var car = new Car();

            car.EngineStart();

            Enumerable.Range(0, 10).ToList().ForEach(s => car.Accelerate(100));

            car.Accelerate(160);
            Assert.AreEqual(110, car.drivingInformationDisplay.ActualSpeed, "Wrong actual speed!");
            car.Accelerate(160);
            Assert.AreEqual(120, car.drivingInformationDisplay.ActualSpeed, "Wrong actual speed!");
            car.Accelerate(160);
            Assert.AreEqual(130, car.drivingInformationDisplay.ActualSpeed, "Wrong actual speed!");
            car.Accelerate(160);
            Assert.AreEqual(140, car.drivingInformationDisplay.ActualSpeed, "Wrong actual speed!");
            car.Accelerate(145);
            Assert.AreEqual(145, car.drivingInformationDisplay.ActualSpeed, "Wrong actual speed!");
        }

        [Test]
        public void TestAccelerateBy5() {
            var car = new Car(30, 5);

            car.EngineStart();

            Enumerable.Range(0, 20).ToList().ForEach(s => car.Accelerate(100));

            car.Accelerate(112);
            Assert.AreEqual(105, car.drivingInformationDisplay.ActualSpeed, "Wrong actual speed!");
            car.Accelerate(112);
            Assert.AreEqual(110, car.drivingInformationDisplay.ActualSpeed, "Wrong actual speed!");
            car.Accelerate(112);
            Assert.AreEqual(112, car.drivingInformationDisplay.ActualSpeed, "Wrong actual speed!");
        }

        [Test]
        public void TestBrakeOnlyOver0() {
            var car = new Car();

            car.EngineStart();

            Enumerable.Range(0, 11).ToList().ForEach(c => car.BrakeBy(10));

            Assert.AreEqual(0, car.drivingInformationDisplay.ActualSpeed, "Wrong actual speed!");
        }

        [Test]
        public void TestAccelerateOnlyUntil250() {
            var car = new Car(20, 20);

            car.EngineStart();

            Enumerable.Range(0, 13).ToList().ForEach(c => car.Accelerate(260));

            Assert.AreEqual(250, car.drivingInformationDisplay.ActualSpeed, "Wrong actual speed!");
        }

        [Test]
        public void TestAccelerateLowerThanActualSpeed() {
            var car = new Car();

            car.EngineStart();

            Enumerable.Range(0, 10).ToList().ForEach(s => car.Accelerate(100));

            car.Accelerate(30);

            Assert.AreEqual(99, car.drivingInformationDisplay.ActualSpeed, "Wrong actual speed!");
        }

        [Test]
        public void TestBraking() {
            var car = new Car();

            car.EngineStart();

            Enumerable.Range(0, 10).ToList().ForEach(s => car.Accelerate(100));

            car.BrakeBy(20);

            Assert.AreEqual(90, car.drivingInformationDisplay.ActualSpeed, "Wrong actual speed!");

            car.BrakeBy(10);

            Assert.AreEqual(80, car.drivingInformationDisplay.ActualSpeed, "Wrong actual speed!");
        }

        [Test]
        public void TestFreeWheelEndingAtZero() {
            var car = new Car();

            car.EngineStart();

            car.Accelerate(5);

            Enumerable.Range(0, 6).ToList().ForEach(s => car.FreeWheel());

            Assert.AreEqual(0, car.drivingInformationDisplay.ActualSpeed, "Wrong actual speed!");
        }

        [Test]
        public void TestNoAccelerationWhenEngineNotRunning() {
            var car = new Car();

            car.Accelerate(5);

            Assert.AreEqual(0, car.drivingInformationDisplay.ActualSpeed, "Wrong actual speed!");
        }

        [Test]
        public void TestConsumptionSpeedUpTo30() {
            var car = new Car(1, 20);

            car.EngineStart();

            car.Accelerate(30);
            car.Accelerate(30);
            car.Accelerate(30);
            car.Accelerate(30);
            car.Accelerate(30);
            car.Accelerate(30);
            car.Accelerate(30);
            car.Accelerate(30);
            car.Accelerate(30);
            car.Accelerate(30);

            Assert.AreEqual(0.98, car.fuelTankDisplay.FillLevel, "Wrong fuel tank fill level!");
        }

        [Test]
        public void TestConsumptionSpeedUpTo80() {
            var car = new Car(1, 20);

            car.EngineStart();

            car.Accelerate(80);
            car.Accelerate(80);
            car.Accelerate(80);
            car.Accelerate(80);

            Enumerable.Range(0, 17).ToList().ForEach(s => car.Accelerate(80));

            Assert.AreEqual(0.97, car.fuelTankDisplay.FillLevel, "Wrong fuel tank fill level!");
        }

        [Test]
        public void TestConsumptionSpeedUpTo120() {
            var car = new Car(1, 20);

            car.EngineStart();

            car.Accelerate(120);
            car.Accelerate(120);
            car.Accelerate(120);
            car.Accelerate(120);
            car.Accelerate(120);
            car.Accelerate(120);

            Enumerable.Range(0, 20).ToList().ForEach(s => car.Accelerate(120));

            Assert.AreEqual(0.95, car.fuelTankDisplay.FillLevel, "Wrong fuel tank fill level!");
        }

        [Test]
        public void TestConsumptionSpeedUpTo250() {
            var car = new Car(1, 20);

            car.EngineStart();

            car.Accelerate(250); // 20
            car.Accelerate(250); // 40
            car.Accelerate(250); // 60
            car.Accelerate(250); // 80
            car.Accelerate(250); // 100
            car.Accelerate(250); // 120
            car.Accelerate(250); // 140
            car.Accelerate(250); // 160
            car.Accelerate(250); // 180
            car.Accelerate(250); // 200
            car.Accelerate(250); // 220
            car.Accelerate(250); // 240
            car.Accelerate(250); // 250

            Assert.AreEqual(0.97, car.fuelTankDisplay.FillLevel, "Wrong fuel tank fill level!");
        }

        [Test]
        public void TestConsumptionLeadsToStopEngine() {
            var car = new Car(1, 20);

            car.EngineStart();

            car.Accelerate(250); // 20
            car.Accelerate(250); // 40
            car.Accelerate(250); // 60
            car.Accelerate(250); // 80
            car.Accelerate(250); // 100
            car.Accelerate(250); // 120
            car.Accelerate(250); // 140
            car.Accelerate(250); // 160
            car.Accelerate(250); // 180
            car.Accelerate(250); // 200
            car.Accelerate(250); // 220
            car.Accelerate(250); // 240
            car.Accelerate(250); // 250

            Enumerable.Range(0, 325).ToList().ForEach(s => car.Accelerate(250));

            Assert.AreEqual(0, car.fuelTankDisplay.FillLevel, "Wrong fuel tank fill level!");
            Assert.IsFalse(car.EngineIsRunning, "Engine could not be running.");
        }

        [Test]
        public void TestConsumptionAsRunIdleWhenFreeWheelingAt0() {
            var car = new Car(1, 20);

            car.EngineStart();

            Enumerable.Range(0, 200).ToList().ForEach(s => car.FreeWheel());

            Assert.AreEqual(0.94, car.fuelTankDisplay.FillLevel, "Wrong fuel tank fill level!");
        }

        [Test]
        public void Car2RandomTests() {
            var rand = new Random();

            for (int i = 0; i < 20; i++) {
                var maxAcceleration = rand.Next(5, 20);
                var expectedSpeed = 0;
                double expectedFuelLevel = 20;

                var car = new Car(20, maxAcceleration);

                car.EngineStart();

                Enumerable.Range(0, 10).ToList().ForEach(s =>
                {
                    car.Accelerate(250);
                    expectedSpeed += maxAcceleration;
                    expectedFuelLevel -= GetConsumption(expectedSpeed);
                });

                var brakeBySpeed = rand.Next(5, 16);

                car.BrakeBy(brakeBySpeed);

                expectedSpeed -= Math.Min(brakeBySpeed, 10);

                var freeWheelSeconds = rand.Next(10, 20);
                Enumerable.Range(0, freeWheelSeconds).ToList().ForEach(c =>
                {
                    car.FreeWheel();
                    if (expectedSpeed > 0) {
                        expectedSpeed--;
                    }
                    if (expectedSpeed == 0) {
                        expectedFuelLevel -= 0.0003;
                    }
                });

                var accelerateSpeed = rand.Next(5, 12);

                car.Accelerate(expectedSpeed + accelerateSpeed);

                expectedSpeed = expectedSpeed + Math.Min(maxAcceleration, accelerateSpeed);

                Assert.AreEqual(expectedSpeed, car.drivingInformationDisplay.ActualSpeed, "Wrong actual speed!");
                Assert.AreEqual(Math.Round(expectedFuelLevel, 2), car.fuelTankDisplay.FillLevel, "Wrong fuel tank fill level!");
            }
        }

        private double GetConsumption(int speed) {
            double consumption = 0.0020;

            if ((speed > 61) && (speed <= 100)) {
                consumption = 0.0014;
            }
            if ((speed > 141) && (speed <= 200)) {
                consumption = 0.0025;
            }
            if ((speed > 201) && (speed <= 250)) {
                consumption = 0.0030;
            }

            return consumption;
        }
    }
}
