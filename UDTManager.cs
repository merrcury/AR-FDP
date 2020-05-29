using System.Collections;
using System.Collections.Generic;
using Unity;
using Vuforia;

public class UDTManager : MonoBehaviour, IUserDefinedTargetEventHandler
{
    UserDefinedTargetBuildingBehaviour udt_targetBuildingBehaviour;
    ObjectTracker objectTracker;
    DataSet dataSet;
    ImageTargetBuilder.FrameQuality udt_FrameQuality;
    public ImageTargetBehaviour targetBehaviour;   

  

    int targetCounter;
    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start() {
        udt_targetBuildingBehaviour = GetComponent<UserDefinedTargetBuildingBehaviour>();
        if (udt_targetBuildingBehaviour){
            udt_targetBuildingBehaviour.RegisterEventHandler(this); 
        }
    }

    public void OnFrameQualityChanged(ImageTargetBuilder.FrameQuality frameQuality) {
        // throw new System.NotImplementedException();
        udt_FrameQuality = frameQuality;
    }

    public  void OnInitialized() {
        objectTracker = TrackerManager.Instance.GetTracker<ObjectTracker>();
        if (objectTracker != null) {
            dataSet = objectTracker.CreateDataSet();
            objectTracker.ActivateDataSet(dataSet);

        }
    }

    public void OnNewTrackableSource(TrackableSource trackableSource) {
        targetCounter++;
        objectTracker.DeactivateDataSet(dataSet);

        dataSet.CreateTrackable(trackableSource, targetBehaviour.gameObject);
        objectTracker.ActivateDataSet(dataSet);

        udt_targetBuildingBehaviour.StartScanning();
        // throw new System.NotImplementedException();
    }

    public void BuildTarget() {
        if (udt_FrameQuality == ImageTargetBuilder.FrameQuality.FRAME_QUALITY_HIGH) {
            udt_targetBuildingBehaviour.BuildNewTarget(targetCounter.ToString(), targetBehaviour.GetSize().x);

        }
    }
}