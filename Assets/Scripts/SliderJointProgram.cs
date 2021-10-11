using System.Collections;
using UnityEngine;

public class SliderJointProgram : MonoBehaviour
{

    private SliderJoint2D sliderJoint;
    private JointMotor2D jointMotor2D;

    public float timeLeft;

    private float positive = 2;
    private float negative = -2;

    private void Start()
    {
        sliderJoint = GetComponent<SliderJoint2D>();
        sliderJoint.useMotor = true;

        jointMotor2D = sliderJoint.motor;

        jointMotor2D.motorSpeed = positive;

        sliderJoint.motor = jointMotor2D;

        StartCoroutine(ActivateSlider());
    }

    public IEnumerator ActivateSlider()
    {
        while(true)
        {


            while (timeLeft > 0.0f)
            {            
                
                timeLeft = timeLeft -= Time.deltaTime;

                jointMotor2D.motorSpeed = positive;

                sliderJoint.motor = jointMotor2D;

                yield return new WaitForEndOfFrame();
            }

            timeLeft = 3;

            while (timeLeft > 0.0f)
            {
                timeLeft = timeLeft -= Time.deltaTime;

                yield return new WaitForEndOfFrame();

                jointMotor2D.motorSpeed = negative;

                sliderJoint.motor = jointMotor2D;

            }

            timeLeft = 3;
        }
    }
}
