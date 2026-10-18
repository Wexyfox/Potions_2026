using NUnit.Framework;
using Potions2026.MouseInteraction;

public class MouseInteractorArbiterTests
{
    private class TestHoverable : IMouseHoverable
    {
        public TestHoverable() { }
        public bool ICanHover() => true;
        public void IStartHovering() { }
        public void IStopHovering() { }
    }

    private class TestInteractable : IMouseInteractable
    {
        public TestInteractable() { }
        public bool ICanInteract() => true;
        public void IStartInteracting() { }
        public void IStopInteracting() { }
    }

    [Test]
    public void ArbiterStartsTrackingHoverable()
    {
        //Assign
        MouseInteractorArbiter mouseInteractorArbiter = MouseInteractorArbiter.Instance;
        TestHoverable testHoverable = new TestHoverable();

        //Act
        mouseInteractorArbiter.StartTrackingHoverable(testHoverable);
        bool startedTrackingHoverable = !mouseInteractorArbiter.Hoverable;
        ClearHoverable(testHoverable);

        //Assert
        Assert.IsTrue(startedTrackingHoverable);
    }

    [Test]
    public void ArbiterStopsTrackingHoverable()
    {
        //Assign
        MouseInteractorArbiter mouseInteractorArbiter = MouseInteractorArbiter.Instance;
        TestHoverable testHoverable = new TestHoverable();

        //Act
        mouseInteractorArbiter.StartTrackingHoverable(testHoverable);
        mouseInteractorArbiter.StopTrackingHoverable(testHoverable);
        bool stoppedTrackingHoverable = mouseInteractorArbiter.Hoverable;
        ClearHoverable(testHoverable);

        //Assert
        Assert.IsTrue(stoppedTrackingHoverable);
    }

    [Test]
    public void ArbiterStartsTrackingInteractable()
    {
        //Assign
        MouseInteractorArbiter mouseInteractorArbiter = MouseInteractorArbiter.Instance;
        TestInteractable testInteractable = new TestInteractable();

        //Act
        mouseInteractorArbiter.StartTrackingInteractable(testInteractable);
        bool startedTrackingInteractable = !mouseInteractorArbiter.Interactable;
        ClearInteractable(testInteractable);

        //Assert
        Assert.IsTrue(startedTrackingInteractable);
    }

    [Test]
    public void ArbiterStopsTrackingInteractable()
    {
        //Assign
        MouseInteractorArbiter mouseInteractorArbiter = MouseInteractorArbiter.Instance;
        TestInteractable testInteractable = new TestInteractable();

        //Act
        mouseInteractorArbiter.StartTrackingInteractable(testInteractable);
        mouseInteractorArbiter.StopTrackingInteractable(testInteractable);
        bool stoppedTrackingInteractable = mouseInteractorArbiter.Interactable;
        ClearInteractable(testInteractable);

        //Assert
        Assert.IsTrue(stoppedTrackingInteractable);
    }

    [Test]
    public void ArbiterStopsBeingHoverableWhenInteracting()
    {
        //Assign
        MouseInteractorArbiter mouseInteractorArbiter = MouseInteractorArbiter.Instance;
        TestInteractable testInteractable = new TestInteractable();

        //Act
        mouseInteractorArbiter.StartTrackingInteractable(testInteractable);
        bool isNotHoverable = !mouseInteractorArbiter.Hoverable;
        ClearInteractable(testInteractable);

        //Assert
        Assert.IsTrue(isNotHoverable);
    }

    private void ClearHoverable(IMouseHoverable hoverable)
    {
        MouseInteractorArbiter.Instance.StopTrackingHoverable(hoverable);
    }

    private void ClearInteractable(IMouseInteractable interactable)
    {
        MouseInteractorArbiter.Instance.StopTrackingInteractable(interactable);
    }
}
