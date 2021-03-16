using UnityEditor;
 
public static class DeselectAll {
    [MenuItem("Edit/My Deselect All _d", false, -101)]
    static void Deselect() {
        Selection.activeGameObject = null;
    }
}