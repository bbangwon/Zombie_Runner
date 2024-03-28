using UnityEngine;

public class EnemyAttack : MonoBehaviour
{    
    [SerializeField] float damage = 40f;
    PlayerHealth target;

    void Start()
    {
        target = FindObjectOfType<PlayerHealth>();
    }

    public void OnDamageTaken()
    {
        Debug.Log(name + " I know you're there!");
    }

    public void AttackHitEvent()
    {
        if(target == null) return;

        target.TakeDamage(damage);
        target.GetComponent<DisplayDamage>().ShowDamageImpact();
    }
}
