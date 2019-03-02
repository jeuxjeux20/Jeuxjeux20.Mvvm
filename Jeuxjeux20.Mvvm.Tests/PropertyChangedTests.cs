using NUnit.Framework;

namespace Jeuxjeux20.Mvvm.Tests
{
    public class PropertyChangedTests
    {
        private class Implementation : PropertyChangedObject
        {
            public void RaiseFor(string name = "Something")
            {
                OnPropertyChanged(name);
            }
        }
        [Test]
        public void PropertyChangedObject_PropertyChanged_Raised()
        {
            var impl = new Implementation();
            var success = false;
            impl.PropertyChanged += (_, e) => success = e.PropertyName == "t";
            impl.RaiseFor("t");
            Assert.That(success, Is.True);
        }
    }
}