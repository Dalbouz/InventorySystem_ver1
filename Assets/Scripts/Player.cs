using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;
    
    public float _horizontal;
    public float _vertical;
    private Vector2 _direction;

    private Animator _animator;
    private Rigidbody2D _rigidBody2D;

    public float DefaultSpeedMovement = 5;
    public float SpeedMovement = 5;
    public float SpeedBoost = 10;
    public float PowerUpDuration = 5;

    private SpriteRenderer _spriteRenderer;

    public EquipItemSO EquippedHead;
    public EquipItemSO EquippedTorso;
    public EquipItemSO EquippedWeapon;
    public EquipItemSO EquippedShield;
    public EquipItemSO EquippedBoots;
    public EquipItemSO EquippedRing1;
    public EquipItemSO EquippedRing2;
    public float Strength;
    public float Dexterity;
    public float Agility;
    public float Intelligence;
    public float Luck;
    private int _currentUnitsCrossed;
    public int NumberOfUnitsCrossedToDamageAnItem;
    public float MaxHealth;
    public float MaxMana;
    public float CurrentHealth;
    public float CurrentMana;
    private void Awake()
    {
        if (gameObject.activeInHierarchy) instance = this;
    }
    void Start()
    {
        _rigidBody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
        if (_animator == null) Debug.LogError("Animator is not found!");
        CurrentHealth = MaxHealth;
        CurrentHealth = MaxMana;
        UiManager.instance.HealthBar.value = MaxHealth;
        UiManager.instance.ManaBar.value = MaxMana;
    }
    private void Update()
    {
        if(_horizontal > 0 || _vertical > 0)
        {
            _currentUnitsCrossed += 1;
            if(_currentUnitsCrossed >= NumberOfUnitsCrossedToDamageAnItem)
            {
                GameManager.instance.ItemDurability();
                _currentUnitsCrossed = 0;
            }
        }
    }
    private void FixedUpdate()
    {
        CalculateMovement();

    }

    public void CalculateMovement()
    {
        if (GameManager.instance.IsInputEnabled)
        {
            _horizontal = Input.GetAxisRaw("Horizontal");
            _vertical = Input.GetAxisRaw("Vertical");
            _direction = new Vector2(_horizontal, _vertical);
            AnimationMovement();
            _direction.Normalize();
            transform.Translate(_direction * SpeedMovement * Time.deltaTime);
            if(SpeedMovement != DefaultSpeedMovement)
            {
                StartCoroutine(FixSpeed());
            }
        }
    }

    public void AnimationMovement()
    {
        if (_vertical == 1) _animator.SetBool(Strings.MoveForward, true);
        else _animator.SetBool("IsWalkingForward", false);
        if (_vertical == -1) _animator.SetBool(Strings.MoveBack, true);
        else _animator.SetBool("IsWalkingBack", false);
        if (_horizontal == -1)
        {
            _animator.SetBool(Strings.MoveLeft, true);
            _spriteRenderer.flipX = true;
        }
        else
        {
            _animator.SetBool(Strings.MoveLeft, false);
            _spriteRenderer.flipX = false;
        }
        if (_horizontal == 1) _animator.SetBool(Strings.MoveRight, true);
        else _animator.SetBool(Strings.MoveRight, false);
    }
 IEnumerator FixSpeed()
    {
        yield return new WaitForSeconds(PowerUpDuration);
        SpeedMovement = DefaultSpeedMovement;
    }
}
