using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;

public class MoveToKnight : Agent
{
    [SerializeField] private Transform targetTransform;
    bool InArena = false;

    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(transform.localPosition);
        sensor.AddObservation(targetTransform.localPosition);
    }

    public override void OnEpisodeBegin()
    {
        //transform.localPosition = new Vector3(Random.Range(-0.6457f, -0.68f), 0.1153f, Random.Range(0.23f,0.33f));
    }

    public override void OnActionReceived(ActionBuffers actions)
    {
        if (!InArena)
        {
            float moveX = actions.ContinuousActions[0];
            float moveZ = actions.ContinuousActions[1];
            float rotateY = actions.ContinuousActions[2];
            float moveSpeed = 0.5f;
            transform.localPosition += new Vector3(moveX, 0, moveZ) * Time.deltaTime * moveSpeed;
        }

    }


    public override void Heuristic( in ActionBuffers actionsOut)
    {
        ActionSegment<float> ContinuousActions = actionsOut.ContinuousActions;
        ContinuousActions[0] = Input.GetAxisRaw("Horizontal");
        ContinuousActions[1] = Input.GetAxisRaw("Vertical");

    }

    private void OnTriggerEnter(Collider other) {
        if (other.TryGetComponent<Goal>(out Goal goal))
        {
            print("enter the arena");
            SetReward(+2f);
            InArena = true;
            EndEpisode();
        }
        if(other.TryGetComponent<Walls>(out Walls wall))
        {
            print("hit the wall");
            SetReward(-1f);
            EndEpisode();
        }

        if(other.TryGetComponent<Tree>(out Tree tree))
        {
            print("hit a tree");
            SetReward(-1f);
            EndEpisode();
        }
    }
}
