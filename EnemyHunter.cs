using UnityEngine;      // Unity's tools: MonoBehaviour, Vector3, Time and the rest.
using UnityEngine.AI;   // NavMeshAgent lives here.

// EnemyHunter.cs, on the enemy. The Oct 15 slides An enemy that hunts you, Line of sight,
// A warning, Spotted and The chase. The warning comes from the Fairness slide: when it spots you,
// it turns red and waits half a second before it chases.
// It only sets a new destination while it can see you. When it loses you,
// it walks to where it last saw you, turns back to its calm color and waits there.
// The class name must match the file name. MonoBehaviour makes it a component.
public class EnemyHunter : MonoBehaviour
{   // Start of the EnemyHunter class.
    [SerializeField] NavMeshAgent agent;      // Drag the enemy in here.
    [SerializeField] Transform player;        // Drag the player in here.
    [SerializeField] float sightRange = 15f;  // How far it can see, in meters.

    [Header("Warning")]                       // A bold label in the Inspector.
    [SerializeField] float warnTime = 0.5f;   // Seconds it waits after it spots you.
    [SerializeField] Renderer look;           // The enemy's renderer, so its color can change.
    // Purple while it looks around. The numbers are red, green and blue, each 0 to 1.
    [SerializeField] Color calmColor = new Color(0.45f, 0.3f, 0.6f);
    // Red once it spots you.
    [SerializeField] Color alertColor = new Color(0.95f, 0.15f, 0.1f);

    bool alert;                // true once it has spotted you.
    float warnLeft;            // Seconds of waiting left before the chase.

    // Unity runs Start once, when you press Play, before the first frame.
    void Start()
    {   // Start of Start.
        // Start calm.
        SetColor(calmColor);
    }   // End of Start.

    // Unity runs Update every frame.
    void Update()
    {   // Start of Update.
        // Right on top of you, its eyes end up inside your capsule, where a ray can't hit you,
        // so touching counts as seeing.
        bool sees = CanSee() || Vector3.Distance(transform.position, player.position + Vector3.up) < 1.2f;
        // Not alert yet?
        if (!alert)
        {   // Start of what runs before it has spotted you.
            // Can't see you? Nothing to do.
            if (!sees) return;
            // It spotted you: red, and a short stop before the chase.
            alert = true;
            // Start the wait.
            warnLeft = warnTime;
            // Hold still for now.
            agent.isStopped = true;
            // Turn red.
            SetColor(alertColor);
            // Done for this frame.
            return;
        }   // End of what runs before it has spotted you.

        // Still waiting?
        if (warnLeft > 0f)
        {   // Start of the wait.
            // Count down.
            warnLeft -= Time.deltaTime;
            // Not done waiting? Stop here.
            if (warnLeft > 0f) return;
            // Done waiting: let it move again.
            agent.isStopped = false;
        }   // End of the wait.

        // Can it see you?
        if (sees)
        {   // Start of the chase.
            // Chase: walk to where you are now.
            agent.SetDestination(player.position);
        }   // End of the chase.
        // It can't see you, and it's done working out its path, and it's arrived?
        else if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance + 0.1f)
        {   // Start of what runs when it has lost you.
            // It lost you and got to where it last saw you.
            alert = false;
            // Calm again.
            SetColor(calmColor);
        }   // End of what runs when it has lost you.
    }   // End of Update.

    // True when the first thing a ray from the enemy's eyes hits is the player.
    bool CanSee()
    {   // Start of CanSee.
        // The eyes: half a meter above the middle of the enemy.
        Vector3 eyes = transform.position + Vector3.up * 0.5f;
        // The player's position is at their feet. One meter up is their middle.
        Vector3 toPlayer = player.position + Vector3.up - eyes;
        // Send a ray from the eyes toward the player. ~0 is every layer. Ignore skips triggers.
        if (!Physics.Raycast(eyes, toPlayer, out RaycastHit hit,
            sightRange, ~0, QueryTriggerInteraction.Ignore))   // Range, all layers, no triggers.
            return false;   // The ray didn't hit anything.
        // The first person PlayerCapsule has a Capsule inside it with its own collider,
        // and that one isn't tagged Player. IsChildOf is true for the player and anything in it.
        return hit.transform.IsChildOf(player);
    }   // End of CanSee.

    // Changes the enemy's color.
    void SetColor(Color c)
    {   // Start of SetColor.
        // Only if a renderer was dragged into Look.
        if (look != null) look.material.color = c;
    }   // End of SetColor.
}   // End of the EnemyHunter class.
