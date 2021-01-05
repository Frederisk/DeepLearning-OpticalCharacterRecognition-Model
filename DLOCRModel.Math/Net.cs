


using System;
using System.Collections.Generic;

using DLOCRModel.Math.Layer;

namespace DLOCRModel.Math {
    public class Net<T> where T : struct, IEquatable<T>, IFormattable {
        private List<ILayer<T>> _layerList;

        public Net() {

        }
    }
}