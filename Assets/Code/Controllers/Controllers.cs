using System;
using System.Collections.Generic;
using Code.Interfaces.MonoBehaviourCycle;


namespace Code.Controllers
{
    public sealed class Controllers : IStartable, IFixedUpdatable, IUpdatable, ILateUpdatable, IDisposable
    {
        #region Fields

        private readonly HashSet<IStartable> _startables = new();
        private readonly HashSet<IFixedUpdatable> _fixedUpdatables = new();
        private readonly HashSet<IUpdatable> _updatables = new();
        private readonly HashSet<ILateUpdatable> _lateUpdatables = new();
        private readonly HashSet<IDisposable> _disposables = new();

        #endregion


        #region Methods

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
            
            if (controller is IDisposable disposable)
                _disposables.Add(disposable);
        }

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
            
            if (controller is IDisposable disposable && _disposables.Contains(disposable))
                _disposables.Remove(disposable);
        }
        
        public void Start()
        {
            foreach (var startable in _startables)
            {
                startable.Start();
            }
        }

        public void FixedUpdate(float fixedDeltaTime)
        {
            foreach (var fixedUpdatable in _fixedUpdatables)
            {
                fixedUpdatable.FixedUpdate(fixedDeltaTime);
            }
        }

        public void Update(float deltaTime)
        {
            foreach (var updatable in _updatables)
            {
                updatable.Update(deltaTime);
            }
        }

        public void LateUpdate(float deltaTime)
        {
            foreach (var lateUpdatable in _lateUpdatables)
            {
                lateUpdatable.LateUpdate(deltaTime);
            }
        }

        public void Dispose()
        {
            foreach (var disposable in _disposables)
            {
                disposable.Dispose();
            }
        }

        #endregion
    }
}