using Godot;

public partial class AudioScript : AudioStreamPlayer
{
    public float volume = 0.5f;
    [Export]
    public AudioStream jumpClip;
    [Export]
    public AudioStream hitClip;
    [Export]
    public AudioStream scoreClip;

    public void PlayJumpSound(){
        // audioSource.PlayOneShot(jumpClip, volume);
        this.Stream = jumpClip;
        this.Play();
    }

    public void PlayHitSound(){
        // audioSource.PlayOneShot(hitClip, volume);
        this.Stream = hitClip;
        this.Play();
    }
    public void PlayScoreSound(){
        // audioSource.PlayOneShot(scoreClip, volume);
        this.Stream = scoreClip;
        this.Play();
    }
    
}
