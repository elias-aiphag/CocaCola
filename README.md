## Coca Cola APP
### AR App that plays video when facing Image Tracker

## Platform

    Mobile AR
## Requierements

    Unity 2021.3.9f1
    AR Foundation 4.2.8
    ARKit XR Plugin 4.2.8
    ARCore xR Plugin 4.2.8
    Magic Leap XR Plugin 6.4.1
    ARKit Face Tracking 4.2.8
    OpenXR Plugin 1.8.1
    
## Scene Setup

    AR Session Origin (ARTrackedImageManager)
        -> On read QR or Image Target (ReferenceImageLibrary)
            -> Instantiate ( 3DEnviroment )
    
    3DEnviroment
        -> Canvas
        -> Offset
            -> SmallVideo (locusion audio)
            -> VideoPlayer0s
            -> VideoPlayer1
            -> Arrow
            -> VideoPlayer2
        -> ARManager (OnStart Removed from 3DEnviroment)
    
