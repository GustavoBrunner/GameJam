using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaveAnimationController : MonoBehaviour
{
    public GameObject naveModel1;
    public GameObject naveModel2;
    public GameObject naveModel3;

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();

        // Inicializa a nave com o primeiro modelo
        naveModel1.SetActive(true);
        naveModel2.SetActive(false);
        naveModel3.SetActive(false);

        // Inicia a sequência de animação
        StartCoroutine(AnimateNave());
    }

    private IEnumerator AnimateNave()
    {
        // Tempo que cada modelo ficará ativo
        float duration = 0.5f;

        // Espera pelo tempo determinado e troca para o próximo modelo
        yield return new WaitForSeconds(duration);
        TransitionToModel(1, 2);

        yield return new WaitForSeconds(duration);
        TransitionToModel(2, 3);

        yield return new WaitForSeconds(duration);
        TransitionToModel(3, 1);
    }

    private void TransitionToModel(int currentModel, int nextModel)
    {
        switch (currentModel)
        {
            case 1:
                naveModel1.SetActive(false);
                break;
            case 2:
                naveModel2.SetActive(false);
                break;
            case 3:
                naveModel3.SetActive(false);
                break;
        }

        switch (nextModel)
        {
            case 1:
                naveModel1.SetActive(true);
                animator.SetTrigger("ToModel1");
                break;
            case 2:
                naveModel2.SetActive(true);
                animator.SetTrigger("ToModel2");
                break;
            case 3:
                naveModel3.SetActive(true);
                animator.SetTrigger("ToModel3");
                break;
        }
    }
}

