using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EncounterDB
{

    #region Encounter
    public static Battle_Encounter ���θ�����_�ο� = new Battle_Encounter(
        name: "���θ����� �ο�",
        precondition: true,
        beforeContext: "���θ��� �ο� �¸��߽��ϴ�.",
        reward: 5
        );

    public static Battle_Encounter ��ü����_�ο� = new Battle_Encounter(
        name: "��ü���� �ο�",
        precondition: true,
        beforeContext: "��ü�� �ο� �¸��߽��ϴ�.",
        reward: 1
        );

    public static Selection_Encounter �޷�����_��� = new Selection_Encounter(
        name: "�޷�����_���",
        precondition: true,
        beforeContext: "<color=green>(������ ��������?)</color>",
        options: new Selection_Encounter.Option[] {
            new(optionScript: "�� ���� Į",
                afterContext: "�� ����� �տ� �� ���� Į�� ��� �־����ϴ�!",
                afterEncounter: ���θ�����_�ο�),
            new(optionScript: "������ ��",
                afterContext: "������ �� ���̷� ���̴� ������� ���� ������ ���� ��Ǫ���� ����ϴ�.",
                afterEncounter: ��ü����_�ο�
                ) }
        );

    public static Selection_Encounter �ָ���_�����_�׸��ڸ�_�߰� = new Selection_Encounter(
        name: "�ָ��� ����� �׸��ڸ� �߰�",
        precondition: true,
        beforeContext: "�ָ��� �� ����� �׸��ڰ� �������ϴ�. �󸶸��� ������ ����ΰ�? �ݰ��� ������ ���� ���� �Ҹ��ƽ��ϴ�.\n" +
                       "\"�����!\"\n" +
                       "�� �Ҹ��� �������, �� ����� �ڸ� ���� �ɾ�ɴϴ�. �׷��� �����Ÿ��� �̻��մϴ�.\n" +
                       "<color=green>(�������̰� �����?)</color>",
        options: new Selection_Encounter.Option[] {
            new (optionScript: "�޷��´�",
                 afterContext: "�� ����� �޷��ɴϴ�. �Ÿ��� �ް��� ����������ϴ�. �׿� ����, ������ �� �� ������ �ͱ��� �������ϴ�.\n",
                 reward: 1,
                 afterEncounter: �޷�����_���
                ),
            new (optionScript: "���ҰŸ���",
                 afterContext: "�� ����� ���ҰŸ��� �ɾ�ɴϴ�. �ٸ��� ��ģ �� �մϴ�."
                ),
            new (optionScript: "���߸� �´�",
                 afterContext: "�� ����� ���߸� �ٰ��ɴϴ�. ������ ����� �Ҿ� ��ó������ �� ���� �ִ� ���Դϴ�.") }
        );

    public static Treasure_Encounter ����_�ܰ�_�߰� = new Treasure_Encounter(
        name: "���� �ܰ� �߰�",
        precondition: true,
        beforeContext: "��ó�� ������ ������ ���Դϴ�.",
        reward: "���� �ܰ�"
        );

    public static Treasure_Encounter ��Į_�߰� = new Treasure_Encounter(
        name: "��Į �߰�",
        precondition: true,
        beforeContext: "��ó�� ������ ������ ���Դϴ�.",
        reward: "��Į"
        );
    #endregion

    public static Scenario �׽�Ʈ�ó����� = new Scenario(
        �ָ���_�����_�׸��ڸ�_�߰�,
        ����_�ܰ�_�߰�,
        ��Į_�߰�
        );
}
