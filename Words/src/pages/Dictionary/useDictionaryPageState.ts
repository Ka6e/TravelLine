import { useState } from "react";
import { useWordStore } from "../../store/store";
import { useNavigate } from "react-router-dom";

export const useDictionaryPageState = () => {
    const store = useWordStore((state) => state);
    const navigate = useNavigate();

    const [anchorEl, setAnchorEl] = useState<null | HTMLElement>(null);
    const [selectedWordId, setSelectedWordId] = useState<string | null>(null);
    const open = Boolean(anchorEl);

    const handleClick = (event: React.MouseEvent<HTMLElement>, wordId: string) => {
        setAnchorEl(event.currentTarget);
        setSelectedWordId(wordId);
    };

    const handleClose = () => {
        setAnchorEl(null);
        setSelectedWordId(null);
    };

    const handleEdit = () => {
        if (selectedWordId) {
            navigate(`/edit-word/${selectedWordId}`);
        }
        handleClose();
    };

    const handleDelete = () => {
        if (selectedWordId) {
            store.deleteWord(selectedWordId);
        }
        handleClose();
    };

    const handleAddNew = () => {
        navigate("/new-word");
    };

    return {
        store,
        anchorEl,
        open,
        handleClick,
        handleClose,
        handleEdit,
        handleDelete,
        handleAddNew,
    };
};
