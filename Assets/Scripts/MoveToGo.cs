using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;

public class MoveToGo : Agent
{
    [SerializeField] private Transform targetTransform;
    [SerializeField] private Material winMaterial;
    [SerializeField] private Material loseMaterial;
    [SerializeField] private MeshRenderer floorMeshRenderer;

    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(transform.localPosition);
        sensor.AddObservation(targetTransform.localPosition);
    
    }

    public override void OnEpisodeBegin()
    {
    }

    public override void OnActionReceived(ActionBuffers actions)
    {
        float moveX = actions.ContinuousActions[0];
        float moveZ = actions.ContinuousActions[1];

        float moveSpeed = 3f;
        transform.localPosition += new Vector3(moveX, 0, moveZ) * Time.deltaTime * moveSpeed;
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
            Animator animator = transform.GetChild(0).GetComponent<Animator>();
            SetReward(+1f);
            floorMeshRenderer.material = winMaterial;
            animator.SetTrigger("fight");
            EndEpisode();
        }
        if(other.TryGetComponent<Walls>(out Walls wall))
        {
            SetReward(-1f);
            floorMeshRenderer.material = loseMaterial;
            EndEpisode();
        }
        
    }
}
