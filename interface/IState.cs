using UnityEngine;
using System.Collections;

/// <summary>
/// ���ׂĂ̏�Ԃ̃C���^�t�F�[�X
/// </summary>
public interface IState {
    /// <summary>
    /// ��Ԕԍ��B���ꂼ��̗񋓑̂��L���X�g���Ďg���̂Ő��l�͋C�ɂ���K�v�͂Ȃ�
    /// </summary>
    int name { get; }

	/// <summary>
	/// ��Ԃ̍X�V
	/// </summary>
	int Update();
}