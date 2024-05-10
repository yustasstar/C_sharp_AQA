﻿using NUnitTests.Lessons;

namespace NUnitTests.Homework
{
    public class CarTests : Lesson3Logic
    {
        #region[TestCases]
        //TODO: Finish car tests here or in Lesson3Logic file folowing example
        [Order(1)]
        [Test, Description("Ensure that Acceleration correctly retrieves the current acceleration")]
        public void TestAcceleration()
        {
            CurrentAcceleration = 50;
            Accelerate(CurrentAcceleration);
            Assert.That(Acceleration, Is.EqualTo(CurrentAcceleration));
        }
        #endregion

        #region[TestCases]
        //TODO: TestCases
        //Test Case 1: Test Acceleration
        //Description: Ensure that the method GetAcceleration correctly retrieves the current acceleration value.
        //Steps:
        //Initialize an instance of Lesson3Logic.
        //Call the GetAcceleration method.
        //Verify that the Acceleration property matches CurrentAcceleration.
        [Test]
        [Order(1)]
        [Description("Verify that the Acceleration property matches CurrentAcceleration")]
        public void TestAccelerationMatchesCurrentAcceleration()
        {
            //Call the GetAcceleration method.
            GetAcceleration();
            
           //Verify that the Acceleration property matches CurrentAcceleration.
           if(Acceleration == CurrentAcceleration);
           {
               
           }
        }

        //Test Case 2: Test GetSpeed with Positive Acceleration
        //Description: Verify that GetSpeed correctly assigns the current speed to the Speed property when the acceleration is positive.
        //Steps:
        [Test]
        [Order(2)]
        public void TestGetSpeedPositiveAcceleration()
        {
            //Set CurrentAcceleration to a positive value.
            CurrentAcceleration = 50;
            
            //Call the GetSpeed method.
            GetSpeed();
            
            //Check that Speed equals CurrentSpeed.
            if (Acceleration > 0)
            {
                Assert.That(Speed, Is.EqualTo(CurrentSpeed));
            }
        }

        //Test Case 3: Test GetDeceleration
        //Description: Check if GetDeceleration correctly calculates deceleration as the difference between current speed and deceleration.
        //Steps:
        //Set a known value for CurrentSpeed and CurrentDeceleration.
        //Invoke GetDeceleration.
        //Ensure Deceleration equals CurrentSpeed - CurrentDeceleration.
        [Test]
        [Order(3)]
        [Description("Ensure Deceleration equals CurrentSpeed - CurrentDeceleration")]
        public void TestDecelerationCorrectCalculation()
        {
            //Set a known value for CurrentSpeed and CurrentDeceleration.
            CurrentSpeed = 100;
            CurrentDeceleration = 50;
            
            //Invoke GetDeceleration.
            GetDeceleration();
            
            //Ensure Deceleration equals CurrentSpeed - CurrentDeceleration.
            if (Deceleration == (CurrentSpeed - CurrentDeceleration));
            {
                
            }
        }

        //Test Case 4: Speed Alert on Exceeding Max Speed
        //Description: Validate that SetSpeedAlert generates the correct alert when the speed exceeds the maximum speed.
        //Steps:
        //Set CurrentSpeed to exceed MaxSpeed.
        //Execute SetSpeedAlert.
        //Confirm that SpeedAlert contains the appropriate warning message.
        [Test]
        [Order(4)]
        [Description("Ensure that SpeedAlert contains the appropriate warning message")]
        public void TestExceedingMaxSpeedAlertWarningMessage()
        {
            //Set CurrentSpeed to exceed MaxSpeed.
            if (CurrentSpeed > MaxSpeed);
            {
                //Execute SetSpeedAlert.
                SetSpeedAlert(CurrentSpeed, MaxSpeed);
                
                //Confirm that SpeedAlert contains the appropriate warning message.
                if (Alert != null)
                {
                    Assert.That(Alert, Does.Contain("Take caution! Speed limit overdue " + (CurrentSpeed - MaxSpeed) + "!"));
                }
            }
        }

        //Test Case 5: Low Charge Alert
        //Description: Test SetChargeAlert for generating a low charge alert when charge falls below the critical level.
        //Steps:
        //Set Charge to just below CriticalCharge.
        //Call SetChargeAlert.
        //Check that SpeedAlert includes the low charge warning.
        [Test]
        [Order(5)]
        [Description("Check that SpeedAlert includes the low charge warning")]
        public void TestLowChargeAlertWarningMessage()
        {
            //Set Charge to just below CriticalCharge.
            if (Charge <= CriticalCharge);
            {
                //Call SetChargeAlert.
                SetChargeAlert();
                
                //Check that SpeedAlert includes the low charge warning.
                if (Alert != null)
                {
                    Assert.That(Alert, Does.Contain("Take caution! Charge Low at " + Charge + "%!"));
                }
            }
        }

        //Test Case 6: Full Charge Alert
        //Description: Check that SetChargeAlert correctly alerts when charge exceeds critical overcharge level.
        //Steps:
        //Set Charge above CriticalOvercharge.
        //Call SetChargeAlert.
        //Verify that SpeedAlert warns about full charge and deceleration charge being disabled.
        [Test]
        [Order(6)]
        [Description("Verify that SpeedAlert warns about full charge and deceleration charge being disabled")]
        public void TestFullChargeAlertWarningMessage()
        {
            //Verify Charge above CriticalOvercharge.
            if (Charge >= CriticalOvercharge)
            {
                //Call SetChargeAlert.
                SetChargeAlert();
                
                //Verify that SpeedAlert warns about full charge and deceleration charge being disabled.
                if (Alert != null)
                {
                    Assert.That(Alert, Does.Contain("Charge Full! Deceleration charging disabled."));
                }
            }
        }

        //Test Case 7: Deceleration Charge Activation Safety
        //Description: Test the logic for enabling or disabling the deceleration charge feature based on the charge level.
        //Steps:
        //Set Charge below CriticalOvercharge.
        //Invoke DecelerationChargeActivation with isActive as true.
        //Confirm that IsDecelerationChargeActive is true.
        [Test]
        [Order(7)]
        [Description("Confirm that IsDecelerationChargeActive is true")]
        public void TestDecelerationChargeActivationSafety()
        { 
            // Check if the charge is below the critical overcharge level and if the deceleration charge is active
            if ((Charge < CriticalOvercharge) && (IsDecelerationChargeActive == true))
            {
                // Assert that the IsDecelerationChargeActive property is true
                Assert.That(IsDecelerationChargeActive, Is.True);
            }
        }

        //Test Case 8: Deceleration Charge Deactivation Safety
        //Description: Ensure that deceleration charging is disabled when charge exceeds the safe threshold.
        //Steps:
        //Set Charge above CriticalOvercharge.
        //Call DecelerationChargeActivation with isActive as true.
        //Ensure IsDecelerationChargeActive is false.
        [Test]
        [Order(8)]
        [Description("Ensure IsDecelerationChargeActive is false")]
        public void TestDecelerationChargeDeactivationSafety()
        {
            // Attempt to activate the deceleration charge feature
            DecelerationChargeActivation(true, CriticalOvercharge);
            
            // Check if the charge is above the critical overcharge level and if the deceleration charge feature is currently inactive
            if (Charge > CriticalOvercharge && IsDecelerationChargeActive == false);
            {
                
            }
        }

        //Test Case 9: Compute Deceleration Charge Power When Active
        //Description: Validate that GetDecelerationChargePower computes the correct power when the feature is active.
        //Steps:
        //Ensure DecelerationChargeMode is true.
        //Call GetDecelerationChargePower with isActive set to true.
        //Check that the returned value equals CurrentSpeed - CurrentAcceleration.
        [Test]
        [Order(9)]
        [Description("Check that the returned value equals CurrentSpeed - CurrentAcceleration")]
        public void TestDecelerationChargePowerWhenActiveReturnsValue()
        {
            //Ensure DecelerationChargeMode is true.
            if (DecelerationChargeMode);
            {
               //Check that the returned value equals CurrentSpeed - CurrentAcceleration.
               if (GetDecelerationChargePower(true) == (CurrentSpeed - CurrentAcceleration));
               {
                    
               }
            }
        }

        //Test Case 10: Compute Deceleration Charge Power When Inactive
        //Description: Check that GetDecelerationChargePower returns 0 when the feature is not active.
        //Steps:
        //Ensure DecelerationChargeMode is true.
        //Invoke GetDecelerationChargePower with isActive set to false.
        //Verify that the result is 0.
        [Test]
        [Order(10)]
        [Description("Verify that the result is 0")]
        public void TestDecelerationChargePowerWhenInactiveReturnsZero()
        {
            //Ensure DecelerationChargeMode is true.
            if (DecelerationChargeMode);
            {
                //Verify that the result is 0 when GetDecelerationChargePower(false).
                if (GetDecelerationChargePower(false) == 0);
                {
                    
                }
            }
        }
        #endregion

    }
}
