using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LayerMaskUtil
{
    public static bool ContainsLayer(LayerMask layerMask, int layer) =>
        (layerMask.value & 1 << layer) > 0;
}
