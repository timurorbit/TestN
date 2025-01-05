using System;
using UniRx;
using UnityEngine;
using Zenject;

namespace MageDefence
{
   [RequireComponent(typeof(Rigidbody))]
    public class PlayerController : MonoBehaviour
   {
       [SerializeField] private float moveSpeed = 5f;
       [SerializeField] private float rotationSpeed = 700f;
       //todo get stats from SO
   
       private IPlayerInput _playerInput;
       private PlayerSpellCaster _playerSpellCaster;
       private ITargetLocator _targetLocator;
       
       private Rigidbody _rigidbody;
   
       [Inject]
       public void Construct(IPlayerInput playerInput, PlayerSpellCaster playerSpellCaster,[Inject(Id = "PlayerLocator")] ITargetLocator targetLocator)
       {
           _playerInput = playerInput;
           _playerSpellCaster = playerSpellCaster;
           _targetLocator = targetLocator;
       }
   
       private void Awake()
       {
           _rigidbody = GetComponent<Rigidbody>();
       }
   
       private void Start()
       {
           Observable.EveryFixedUpdate()
               .Subscribe(_ => Move(_playerInput.MoveDirection.Value))
               .AddTo(this);

           Observable.EveryFixedUpdate()
               .Subscribe(_ => Rotate(_playerInput.MoveDirection.Value))
               .AddTo(this);

           Observable.EveryUpdate()
               .Subscribe(_ => CastSpell(_playerInput.SpellInput.Value))
               .AddTo(this);
           
           _playerInput.SpellChange
               .Subscribe(ChangeSpell)
               .AddTo(this);
       }

       private void Update()
       {
           _playerInput.HandleInput();
       }

       private void ChangeSpell(int direction)
       {
          _playerSpellCaster.ChangeSpell(direction); 
       }

       private void Move(Vector3 direction)
       {
           if (direction != Vector3.zero)
           {
               Vector3 movement = direction * moveSpeed * Time.deltaTime;
               _rigidbody.MovePosition(_rigidbody.position + movement);  
           }
       }

       private void Rotate(Vector3 direction)
       {
           if (direction != Vector3.zero)
           {
               Quaternion targetRotation = Quaternion.LookRotation(direction);
               _rigidbody.MoveRotation(Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime));
           }
       }

       private void CastSpell(bool spellInputValue)
       {
           if (!spellInputValue)
           {
               return;
           }

           _playerSpellCaster.CastSpell();
       }

       private void OnEnable()
       {
           _targetLocator.RegisterTarget(transform);
       }

       private void OnDisable()
       {
           _targetLocator.UnregisterTarget(transform);
       }
   } 
}
