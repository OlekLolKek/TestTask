using System.Collections.Generic;
using Code.Interfaces.MonoBehaviourCycle;


namespace Code.Controllers
{
    /// <summary>
    /// Stores controllers and calls Unity event methods on each one.
    /// </summary>
    public sealed class Controllers : IStartable, IFixedUpdatable, IUpdatable, ILateUpdatable, ICleanable
    {
        #region Fields

        private readonly HashSet<IStartable> _startables = new();
        private readonly HashSet<IFixedUpdatable> _fixedUpdatables = new();
        private readonly HashSet<IUpdatable> _updatables = new();
        private readonly HashSet<ILateUpdatable> _lateUpdatables = new();
        private readonly HashSet<ICleanable> _cleanables = new();

        #endregion


        #region Methods

        /// <summary>
        /// Used to add a controller to the lists. The specified controller should inherit at least one of the event interfaces:
        /// IStartable, IFixedUpdatable, IUpdatable, ILateUpdatable or ICleanable
        /// </summary>
        /// <param name="controller">The controller that needs to be added to the list</param>
        public void AddController(IController controller)
        {
            if (controller is IStartable startable)
                _startables.Add(startable);
            
            if (controller is IFixedUpdatable fixedUpdatable)
                _fixedUpdatables.Add(fixedUpdatable);
            
            if (controller is IUpdatable updatable)
                _updatables.Add(updatable);
            
            if (controller is ILateUpdatable lateUpdatable)
                _lateUpdatables.Add(lateUpdatable);
            
            if (controller is ICleanable cleanable)
                _cleanables.Add(cleanable);
        }

        /// <summary>
        /// Used to remove a controller from the lists. The specified controller should inherit at least one of the event interfaces:
        /// IStartable, IFixedUpdatable, IUpdatable, ILateUpdatable or ICleanable
        /// The controller won't be removed if it's not already in the lists.
        /// </summary>
        /// <param name="controller">The controller that needs to be removed from the list</param>
        public void RemoveController(IController controller)
        {
            if (controller is IStartable startable && _startables.Contains(startable))
                _startables.Remove(startable);
            
            if (controller is IFixedUpdatable fixedUpdatable && _fixedUpdatables.Contains(fixedUpdatable))
                _fixedUpdatables.Remove(fixedUpdatable);
            
            if (controller is IUpdatable updatable && _updatables.Contains(updatable))
                _updatables.Remove(updatable);
            
            if (controller is ILateUpdatable lateUpdatable && _lateUpdatables.Contains(lateUpdatable))
                _lateUpdatables.Remove(lateUpdatable);
            
            if (controller is ICleanable cleanable && _cleanables.Contains(cleanable))
                _cleanables.Remove(cleanable);
        }
        
        /// <summary>
        /// Calls Start() on every controller added.
        /// </summary>
        public void Start()
        {
            foreach (var startable in _startables)
            {
                startable.Start();
            }
        }

        /// <summary>
        /// Calls FixedUpdate on every controller added.
        /// </summary>
        /// <param name="fixedDeltaTime">The Time.fixedDeltaTime value for the current physics update frame.</param>
        public void FixedUpdate(float fixedDeltaTime)
        {
            foreach (var fixedUpdatable in _fixedUpdatables)
            {
                fixedUpdatable.FixedUpdate(fixedDeltaTime);
            }
        }

        /// <summary>
        /// Calls Update on every controller added.
        /// </summary>
        /// <param name="deltaTime">The Time.deltaTime value for the current frame.</param>
        public void Update(float deltaTime)
        {
            foreach (var updatable in _updatables)
            {
                updatable.Update(deltaTime);
            }
        }
        
        /// <summary>
        /// Calls LateUpdate on every controller added.
        /// </summary>
        /// <param name="deltaTime">The Time.deltaTime value for the current frame.</param>
        public void LateUpdate(float deltaTime)
        {
            foreach (var lateUpdatable in _lateUpdatables)
            {
                lateUpdatable.LateUpdate(deltaTime);
            }
        }

        /// <summary>
        /// Calls Cleanup on every controller added. The main Cleanup method is usually called from OnDestroy() of the entry point class.
        /// </summary>
        public void Cleanup()
        {
            foreach (var cleanable in _cleanables)
            {
                cleanable.Cleanup();
            }
        }

        #endregion
    }
}