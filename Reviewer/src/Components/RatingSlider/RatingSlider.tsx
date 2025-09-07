import { useState, useEffect } from "react";
import { EmojiIcon } from "../Emoji/Emoji";
import styles from "./RatingSlider.module.css";

type RatingSliderType = {
    name: string;
    value?: number;
    onChange: (value: number) => void;
};

export const RatingSlider = ({ name, value = 0, onChange }: RatingSliderType) => {
    const [ratingValue, setRatingValue] = useState(value);
    const [isInteracting, setIsInteracting] = useState(false);

    useEffect(() => {
        setRatingValue(value);
    }, [value]);

    const handleChange = (newValue: number) => {
        setRatingValue(newValue);
        onChange(newValue);
        if (!isInteracting) setIsInteracting(true);
    };

    const getSmiley = (val: number) => <EmojiIcon value={val} />;

    const getSectionColor = (point: number) => {
        switch (point) {
            case 1: return "#ff4444";
            case 2:
            case 3: return "#ff8c00";
            case 4:
            case 5: return "#ffcc00";
            default: return "#DCDCDC";
        }
    };

    const getDotColor = (point: number) => {
        if (!isInteracting && value === 0) return getSectionColor(point);
        if (ratingValue > 0) return point <= ratingValue ? getSectionColor(ratingValue) : "#FFFFFF";
        return "#FFFFFF";
    };

    return (
        <div className={styles.sliderContainer}>
            <div className={styles.container}>
                <input
                    type="range"
                    min={1}
                    max={5}
                    step={1}
                    value={ratingValue}
                    onChange={(e) => handleChange(parseInt(e.target.value))}
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
                                onClick={() => handleChange(point)}
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