import { EmojiIcon } from "../Emoji/Emoji";
import styles from "./RatingSlider.module.css";
import { useRatingSlider } from "../../hooks/useRatingSlider";

type RatingSliderType = {
    name: string;
    value?: number;
    onChange: (value: number) => void;
};

export const RatingSlider = ({ name, value = 0, onChange }: RatingSliderType) => {
    const { ratingValue, isInteracting, handleChange, getSectionColor, getDotColor } =
        useRatingSlider(value);

    const handleChangeWithCallback = (val: number) => {
        handleChange(val);
        onChange(val);
    };

    const getSmiley = (val: number) => <EmojiIcon value={val} />;

    return (
        <div className={styles.sliderContainer}>
            <div className={styles.container}>
                <input
                    type="range"
                    min={1}
                    max={5}
                    step={1}
                    value={ratingValue}
                    onChange={(e) => handleChangeWithCallback(parseInt(e.target.value))}
                    className={styles.sliderInput}
                    name={name}
                />
                <div className={styles.sliderTrackBackground}></div>
                {isInteracting && ratingValue > 0 && (
                    <div
                        className={styles.sliderTrackFill}
                        style={{
                            width: `${((ratingValue - 1) / 4) * 100}%`,
                            backgroundColor: getSectionColor(ratingValue),
                        }}
                    />
                )}
                <div className={styles.sliderTrack}>
                    {Array.from({ length: 5 }, (_, i) => {
                        const point = i + 1;
                        return (
                            <div
                                key={point}
                                className={styles.sliderDot}
                                style={{
                                    left: `${(i / 4) * 100}%`,
                                    backgroundColor: getDotColor(point),
                                }}
                                onClick={() => handleChangeWithCallback(point)}
                            />
                        );
                    })}

                    {isInteracting && ratingValue > 0 && (
                        <div
                            className={styles.sliderThumb}
                            style={{ left: `${((ratingValue - 1) / 4) * 100}%` }}
                        >
                            {getSmiley(ratingValue)}
                        </div>
                    )}
                </div>
            </div>
            <p className={styles.text}>{name}</p>
        </div>
    );
};
