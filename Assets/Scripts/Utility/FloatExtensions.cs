using UnityEngine;

public static class FloatExtensions {
    public static float ClampAngle(this float angle, float min = 0, float max = 360) {
        if (angle < 90 || angle > 270) {
            if (angle > 180) angle -= 360;
            if (max > 180) max -= 360;
            if (min > 180) min -= 360;
        }

        angle = Mathf.Clamp(angle, min, max);
        if (angle < 0) angle += 360;

        return angle;
    }
}